using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBatchWatermarkRemoval
{
    public partial class Form1 : Form
    {
        private string sourceFolder = null;
        private string resultFolder = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Roy0309");
        }

        private void btn_Source_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "选择要批量去水印的源图片文件夹。",
                ShowNewFolderButton = false
            };
            fbd.ShowDialog();
            if (string.IsNullOrEmpty(fbd.SelectedPath)) { return; }
            sourceFolder = fbd.SelectedPath;
            tb_Source.Text = sourceFolder;

            resultFolder = Path.Combine(sourceFolder.Substring(0, sourceFolder.LastIndexOf("\\") + 1), "Result");
            tb_Result.Text = resultFolder;
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Source.Text)) { return; }
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "选择结果图片文件夹。",
                ShowNewFolderButton = false
            };
            fbd.ShowDialog();
            if (string.IsNullOrEmpty(fbd.SelectedPath)) { return; }
            resultFolder = fbd.SelectedPath;
            tb_Result.Text = resultFolder;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(resultFolder);
            backgroundWorker1.RunWorkerAsync();
        }

        private static List<string> imageExtensions = new List<string>() { ".jpg", ".jpeg", ".png" };

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get images
            FileInfo[] files = new DirectoryInfo(sourceFolder).EnumerateFiles()
                .Where(u => imageExtensions.Contains(u.Extension))
                .ToArray();
            progressBar1.Invoke(new Action(() => 
            { 
                progressBar1.Maximum = files.Length; 
                progressBar1.Value = 0; 
            }));
            
            // Remove watermark
            int handledCount = 0;
            Parallel.ForEach(files, fi =>
            {
                bool handled = RemoveWatermark(fi.Name, 690);
                if (handled) { handledCount++; }
                progressBar1.Invoke(new Action(() => progressBar1.Value++));
            });

            watch.Stop();
            e.Result = new double[3] { files.Length, handledCount, watch.ElapsedMilliseconds };
            GC.Collect();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double[] result = (double[])e.Result;
            MessageBox.Show($"源文件夹共有 {result[0]} 张图片，已处理 {result[1]} 张图片，用时 {result[2] / 1000} 秒。\n即将打开结果文件夹。", 
                "结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(resultFolder);
        }

        public bool RemoveWatermark(string filename, int colorThreshold)
        {
            Mat src = new Mat(Path.Combine(sourceFolder, filename));
            if (src.Height < 150) { return false; }
            Mat mask = new Mat(src.Size(), MatType.CV_8UC1, new Scalar(0));

            // Scan the bottom of image       
            Parallel.For(src.Height - 150, src.Height, j =>
            {
                for (int i = 0; i < src.Width; i++)
                {
                    Vec3b color = src.Get<Vec3b>(j, i);
                    // Find pixels with high RGB
                    if (color[0] + color[1] + color[2] < colorThreshold) { continue; }

                    for (int dj = -3; dj <= 3; dj++)
                    {
                        for (int di = -3; di <= 3; di++)
                        {
                            if (j + dj < src.Height && i + di < src.Width) // Prevent index out of bounds
                            {
                                mask.Set<byte>(j + dj, i + di, 255);
                            }
                        }
                    }
                }
            });

            mask = mask.Dilate(new Mat());

            // Find connected components
            Mat labels = new Mat();
            Mat stats = new Mat();
            int num = mask.ConnectedComponentsWithStats(labels, stats, new Mat());

            // Prepare to remove small connected components
            byte[] colors = new byte[num];
            Parallel.For(1, num, i =>
            {
                colors[i] = (byte)(stats.At<int>(i, 4/* Area */) < 300 ? 0 : 255);
            });
            stats.Dispose();

            // Remove small connected components
            int brightPixelCount = 0;
            Parallel.For(0, src.Width, i =>
            {
                for (int j = src.Height - 150; j < src.Height; j++)
                {
                    int label = labels.At<int>(j, i);
                    mask.Set(j, i, colors[label]);
                    if (colors[label] > 0) { brightPixelCount++; }
                }
            });
            labels.Dispose();

            // If the proportion of bright pixels is greater then 1/150, that is, 
            // many pixels which do not belong to watermarks have been mishandled,
            // quit processing.
            if (brightPixelCount == 0 ||
                brightPixelCount * 150 > src.Width * (src.Height - 150))
            {
                mask.Dispose();
                src.Dispose();
                return false;
            }

            // Save mask
            //mask.SaveImage(Path.Combine(maskFolder, filename));

            // Generate watermark-removed images
            using (var result = new Mat())
            {
                Cv2.Inpaint(src, mask, result, 5.0, InpaintMethod.Telea);
                result.SaveImage(Path.Combine(resultFolder, filename));
            }

            // Free resources
            mask.Dispose();
            src.Dispose();

            return true;
        }
    }
}

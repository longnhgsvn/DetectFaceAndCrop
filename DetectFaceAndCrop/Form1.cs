using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DetectFaceAndCrop
{
    public partial class Form1 : Form
    {
        // Detection settings
        private const double FaceScaleFactor = 1.1;
        private const int FaceMinNeighbors = 10;
        private const int MinFaceSize = 40;

        // Output card settings
        private const int OutputWidth = 248;
        private const int OutputHeight = 340;
        private const int TargetFaceWidth = 197;
        private const int FaceCenterX = 128;
        private const int FaceCenterY = 150;

        private readonly List<string> _files = new List<string>();
        private CascadeClassifier _cascadeClassifier;
        private Image<Bgr, byte> _originalPreview;
        private Bitmap _resultPreview;
        private bool _isProcessing;

        public Form1()
        {
            InitializeComponent();
            UpdateButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cascadePath = Path.Combine(Application.StartupPath, "haarcascade_frontalface_default.xml");

            try
            {
                if (!File.Exists(cascadePath))
                {
                    throw new FileNotFoundException("The face detection model file was not found.", cascadePath);
                }

                _cascadeClassifier = new CascadeClassifier(cascadePath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Face detection model could not be loaded.";
                MessageBox.Show(
                    this,
                    "Could not load the face detection model:" + Environment.NewLine + ex.Message,
                    "Face detection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            UpdateButtons();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            originalImageBox.Image = null;
            croppedPictureBox.Image = null;

            if (_originalPreview != null)
            {
                _originalPreview.Dispose();
                _originalPreview = null;
            }

            if (_resultPreview != null)
            {
                _resultPreview.Dispose();
                _resultPreview = null;
            }

            if (_cascadeClassifier != null)
            {
                _cascadeClassifier.Dispose();
                _cascadeClassifier = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                AddFiles(openFileDialog.FileNames);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _files.Clear();
            filesListBox.Items.Clear();
            ClearResult();
            lblStatus.Text = "List cleared. Add images to get started.";
            UpdateButtons();
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            string outputDirectory = _files.Count > 0
                ? Path.Combine(Path.GetDirectoryName(_files[0]), "PROCESS")
                : null;

            if (string.IsNullOrEmpty(outputDirectory) || !Directory.Exists(outputDirectory))
            {
                MessageBox.Show(
                    this,
                    "No output folder yet. Process at least one image first.",
                    "Output folder",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Process.Start("explorer.exe", "\"" + outputDirectory + "\"");
        }

        private void filesListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedFiles();
                e.Handled = true;
            }
        }

        private void filesListBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void filesListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths != null)
            {
                AddFiles(paths);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (_isProcessing)
            {
                return;
            }

            if (_cascadeClassifier == null)
            {
                MessageBox.Show(
                    this,
                    "The face detection model is not available, so images cannot be processed.",
                    "Face detection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_files.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Add at least one image before processing.",
                    "No images",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] files = _files.ToArray();
            int exported = 0;
            int skipped = 0;

            SetProcessing(true);
            progressBar.Maximum = files.Length;
            progressBar.Value = 0;

            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    lblStatus.Text = string.Format(
                        "Processing {0} of {1}: {2}",
                        i + 1,
                        files.Length,
                        Path.GetFileName(files[i]));
                    Refresh();
                    Application.DoEvents();

                    try
                    {
                        if (ProcessFile(files[i]))
                        {
                            exported++;
                        }
                        else
                        {
                            skipped++;
                        }
                    }
                    catch (Exception ex)
                    {
                        skipped++;
                        Debug.WriteLine("Failed to process " + files[i] + ": " + ex);
                    }

                    progressBar.Value = i + 1;
                }
            }
            finally
            {
                SetProcessing(false);
            }

            lblStatus.Text = string.Format(
                "Done. {0} photo(s) exported, {1} image(s) skipped.",
                exported,
                skipped);
        }

        /// <summary>
        /// Detects all faces, shows them on the preview and saves the largest face
        /// as a 248 x 340 ID photo in a PROCESS folder next to the source image.
        /// </summary>
        private bool ProcessFile(string path)
        {
            using (Bitmap source = LoadBitmap(path))
            using (var frame = new Image<Bgr, byte>(source))
            {
                Rectangle[] faces;
                using (var gray = frame.Convert<Gray, byte>())
                {
                    faces = _cascadeClassifier.DetectMultiScale(
                        gray,
                        FaceScaleFactor,
                        FaceMinNeighbors,
                        new Size(MinFaceSize, MinFaceSize));
                }

                if (faces == null || faces.Length == 0)
                {
                    ShowOriginal(frame);
                    ClearResult();
                    return false;
                }

                foreach (Rectangle face in faces)
                {
                    frame.Draw(face, new Bgr(Color.FromArgb(0, 176, 255)), 2);
                }

                ShowOriginal(frame);

                Rectangle primary = faces[0];
                foreach (Rectangle face in faces)
                {
                    if ((long)face.Width * face.Height > (long)primary.Width * primary.Height)
                    {
                        primary = face;
                    }
                }

                double scale = (double)TargetFaceWidth / primary.Width;
                int scaledWidth = Math.Max(1, (int)Math.Round(source.Width * scale));
                int scaledHeight = Math.Max(1, (int)Math.Round(source.Height * scale));

                using (var scaled = new Bitmap(source, scaledWidth, scaledHeight))
                using (var card = new Bitmap(OutputWidth, OutputHeight, PixelFormat.Format24bppRgb))
                {
                    using (var graphics = Graphics.FromImage(card))
                    {
                        graphics.Clear(Color.White);
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        double centerX = (primary.X + primary.Width / 2.0) * scale;
                        double centerY = (primary.Y + primary.Height / 2.0) * scale;
                        int left = (int)Math.Round(FaceCenterX - centerX);
                        int top = (int)Math.Round(FaceCenterY - centerY);

                        graphics.DrawImage(scaled, new Rectangle(left, top, scaled.Width, scaled.Height));
                    }

                    ShowResult(card);

                    string outputDirectory = Path.Combine(Path.GetDirectoryName(path), "PROCESS");
                    Directory.CreateDirectory(outputDirectory);

                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(path) + ".png");

                    card.Save(outputPath, ImageFormat.Png);
                }

                return true;
            }
        }

        private static Bitmap LoadBitmap(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var image = Image.FromStream(stream))
            {
                return new Bitmap(image);
            }
        }

        private void ShowOriginal(Image<Bgr, byte> frame)
        {
            Image<Bgr, byte> next = frame.Copy();
            Image<Bgr, byte> previous = _originalPreview;

            _originalPreview = next;
            originalImageBox.Image = _originalPreview;

            if (previous != null)
            {
                previous.Dispose();
            }
        }

        private void ShowResult(Bitmap card)
        {
            Bitmap next = new Bitmap(card);
            Bitmap previous = _resultPreview;

            _resultPreview = next;
            croppedPictureBox.Image = _resultPreview;

            if (previous != null)
            {
                previous.Dispose();
            }
        }

        private void ClearResult()
        {
            croppedPictureBox.Image = null;

            if (_resultPreview != null)
            {
                _resultPreview.Dispose();
                _resultPreview = null;
            }
        }

        private void AddFiles(IEnumerable<string> paths)
        {
            bool added = false;

            foreach (string path in paths)
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    continue;
                }

                string fullPath;
                try
                {
                    fullPath = Path.GetFullPath(path);
                }
                catch
                {
                    continue;
                }

                if (!File.Exists(fullPath))
                {
                    continue;
                }

                if (_files.Any(f => string.Equals(f, fullPath, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                _files.Add(fullPath);
                filesListBox.Items.Add(Path.GetFileName(fullPath));
                added = true;
            }

            if (added)
            {
                lblStatus.Text = string.Format("{0} image(s) in the list.", _files.Count);
                UpdateButtons();
            }
        }

        private void RemoveSelectedFiles()
        {
            if (filesListBox.SelectedIndices.Count == 0)
            {
                return;
            }

            int[] indices = filesListBox.SelectedIndices
                .Cast<int>()
                .OrderByDescending(i => i)
                .ToArray();

            foreach (int index in indices)
            {
                filesListBox.Items.RemoveAt(index);
                _files.RemoveAt(index);
            }

            UpdateButtons();
            lblStatus.Text = string.Format("{0} image(s) in the list.", _files.Count);
        }

        private void SetProcessing(bool isProcessing)
        {
            _isProcessing = isProcessing;
            progressBar.Visible = isProcessing;
            UseWaitCursor = isProcessing;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            btnBrowse.Enabled = !_isProcessing;
            btnClear.Enabled = !_isProcessing && _files.Count > 0;
            btnProcess.Enabled = !_isProcessing && _files.Count > 0 && _cascadeClassifier != null;
            btnOpenOutput.Enabled = !_isProcessing;
            filesListBox.Enabled = !_isProcessing;
        }
    }
}

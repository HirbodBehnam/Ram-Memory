using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class DownloadForm : Form
    {
        private WebClient _webClient;
        public ListView Lv;
        private bool _downloading;
        private DateTime _lastUpdate;
        private long _lastBytes;
        public DownloadForm()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (_downloading)
            {
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }
            Uri url;
            try
            {
                url = new Uri(textBoxUrl.Text);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("URL is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nDetailed Error:\n" + ex, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += (s, ev) =>
            {
                progressBar.Value = ev.ProgressPercentage;
                ProgressChanged(ev.BytesReceived);
            };
            _webClient.DownloadDataCompleted += (s, ev) =>
            {
                _downloading = false;
                if(ev.Cancelled)
                    return;
                if (ev.Error != null)
                {
                    MessageBox.Show(ev.Error.Message + "\n\nDetailed Error:\n" + ev.Error, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                string filename;
                if (url.IsFile)
                    filename = Path.GetFileName(url.LocalPath);
                else
                {
                    filename = Uri.UnescapeDataString(url.Segments.Last());
                    if (string.IsNullOrWhiteSpace(filename))
                        filename = "DownloadedFile";
                    if (Main.Data.ContainsKey(filename))
                    {
                        int i = 2;
                        while (Main.Data.ContainsKey(filename + i))
                            i++;
                        filename += i;
                    }
                }
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.NumberDecimalDigits = 0;
                Main.Data.Add(filename, ev.Result);
                Lv.Items.Add(new ListViewItem(new[]
                    {filename, ev.Result.Length.ToString("N", nfi)}));
                MessageBox.Show("Download complete! Saved as " + filename, "Done", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            };
            try
            {
                _downloading = true;
                _webClient.DownloadDataAsync(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nDetailed Error:\n" + ex, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ProgressChanged(long bytes)
        {
            if (_lastBytes == 0)
            {
                _lastUpdate = DateTime.Now;
                _lastBytes = bytes;
                return;
            }

            var now = DateTime.Now;
            var timeSpan = now - _lastUpdate;
            if(timeSpan.Seconds == 0)
                return;
            long bytesChange = bytes - _lastBytes;
            long bytesPerSecond = bytesChange / timeSpan.Seconds;

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberDecimalDigits = 0;
            labelResult.Text = bytesPerSecond.ToString("N",nfi) + " bytes/s";

            _lastBytes = bytes;
            _lastUpdate = now;
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_downloading)
            {
                if (MessageBox.Show("Cancel download?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _webClient.CancelAsync();
                }
            }
        }
    }
}

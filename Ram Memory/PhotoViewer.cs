using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class PhotoViewer : Form
    {
        public string Key;
        public PhotoViewer()
        {
            InitializeComponent();
        }

        private void PhotoViewer_Load(object sender, EventArgs e)
        {
            Text = Key;
            Bitmap b = ByteToImage(Main.Data[Key]);
            if(b == null)
                Close();
            pictureBox1.Image = b;
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            try
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nDetailed Error:\n" + ex, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return null;
        }
    }
}

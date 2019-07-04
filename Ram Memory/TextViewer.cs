using System;
using System.Text;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class TextViewer : Form
    {
        public ListView Lv;
        public string Key;
        public int Index;
        private bool _needSave;
        public TextViewer()
        {
            InitializeComponent();
        }
        private void TextViewer_Load(object sender, EventArgs e)
        {
            string s = Encoding.Default.GetString(Main.Data[Key]);
            if (s.Length > 8388608)
            {
                MessageBox.Show("Cannot read files that are more than 8,388,608 characters.","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Close();
            }
            textBoxMain.Text = s;
            _needSave = false;
            Text = Text.Remove(Text.Length - 1);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.S))
            {
                Save();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ToolStripButton1_Click(object sender, EventArgs e) => Save();
        private void TextBoxMain_TextChanged(object sender, EventArgs e)
        {
            _needSave = true;
            if(!Text.EndsWith("*"))
                Text += "*";
        }

        private void Save()
        {
            if(!_needSave)
                return;
            _needSave = false;
            Text = Text.Remove(Text.Length - 1);
            Main.Data[Key] = Encoding.Default.GetBytes(textBoxMain.Text);
        }

        private void TextViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_needSave)
                if (MessageBox.Show("The file has not been saved. Close text viewer?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ==
                    DialogResult.No)
                    e.Cancel = true;
            Lv.Items[Index] = new ListViewItem(new []{Lv.Items[Index].Text,Main.Data[Key].Length.ToString()});
        }

    }
}

using System;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            checkBoxGC.Checked = Properties.Settings.Default.GCAfterDelete;
            checkBoxSecureDelete.Checked = Properties.Settings.Default.RewriteDataByZero;
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GCAfterDelete = checkBoxGC.Checked;
            Properties.Settings.Default.RewriteDataByZero = checkBoxSecureDelete.Checked;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}

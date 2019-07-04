using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) => Process.Start("https://github.com/HirbodBehnam/Ram-Memory");
    }
}

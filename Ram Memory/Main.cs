using Microsoft.VisualBasic.Devices;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ram_Memory
{
    public partial class Main : Form
    {
        public static Dictionary<string,byte[]> Data = new Dictionary<string, byte[]>();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FirstRun)
            {
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
                MessageBox.Show(
                    "EVERY THING YOU STORE HERE WILL BE STORED IN YOUR RAM. IF YOU CLOSE THE APPLICATION YOU WILL BASICALLY DELETE EVERYTHING FROM YOUR MEMORY.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listViewMain.Items.Count != 0)
                if (MessageBox.Show("You have files in your RAM. Do you want to delete them all?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) ==
                    DialogResult.No)
                    e.Cancel = true;
        }
        
        private void ListViewMain_MouseClick(object sender, MouseEventArgs e)
        {
            //https://stackoverflow.com/a/13438078/4213397
            if (e.Button == MouseButtons.Right)
            {
                if (listViewMain.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStripFiles.Show(Cursor.Position);
                }
            } 
        }
        private void ListViewMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewMain.SelectedItems.Count != 0)
                if (MessageBox.Show("Are you sure you want to delete \"" + listViewMain.SelectedItems[0].Text +"\" file? This action cannot be undone.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    DeleteFile();
        }
        
        #region ToolStrip Actions
        private void ToolStripAbout_Click(object sender, EventArgs e) => new About().ShowDialog();
        private void ToolStripSettings_Click(object sender, EventArgs e) => new SettingsForm().ShowDialog();
        private void ToolStripOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog {Title = "Choose a File To Load It To Memory"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofd.FileName);
                //C# supports files upto 2GB
                if (file.Length > int.MaxValue)
                {
                    MessageBox.Show("Cannot load a file more than 2 gigabytes. Please split the file.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //This checks that user have enough memory to load the file
                if ((ulong)file.Length > new ComputerInfo().AvailablePhysicalMemory)
                    if(MessageBox.Show("You have less RAM than the file you are about to load. If you continue, the application may crash.\nContinue?",
                           "Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,
                           MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                //This checks if the file exists in data or not.
                string nameToAdd;
                if (Data.ContainsKey(file.Name))
                {
                    //If file exists, add a number to end of it's name
                    int i = 2;
                    while (Data.ContainsKey(Path.GetFileNameWithoutExtension(file.Name) + i + "." + file.Extension))
                        i++;
                    nameToAdd = Path.GetFileNameWithoutExtension(file.Name) + i + "." + file.Extension;
                }
                else
                    nameToAdd = file.Name;
                //Now load the data
                LoadingForm dialog = new LoadingForm {labelMain = {Text = "Loading From Disk. Please Wait..."}};
                Main main = this;
                new Task(() =>
                {
                    try
                    {
                        Data.Add(nameToAdd, File.ReadAllBytes(ofd.FileName));
                        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                        nfi.NumberDecimalDigits = 0;
                        listViewMain.Invoke((MethodInvoker)(() => listViewMain.Items.Add(new ListViewItem(new[] {nameToAdd, file.Length.ToString("N",nfi)}))));
                        main.Invoke((MethodInvoker)(() => dialog.Close()));
                    }
                    catch (Exception ex)
                    {
                        main.Invoke((MethodInvoker)(() => dialog.Close()));
                        MessageBox.Show(ex.Message + "\n\nDetailed Error:\n" + ex, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }).Start();
                dialog.ShowDialog();
            }
        }
        private void ToolStripDownloadFile_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
        
        
        #region Menu Buttons
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listViewMain.SelectedItems.Count == 0)
                return;
            string key = listViewMain.SelectedItems[0].Text;
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save File", FileName = key, Filter = "All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                LoadingForm dialog = new LoadingForm {labelMain = {Text = "Saving File. Please Wait..."}};
                Main main = this;
                new Task(() =>
                {
                    try
                    {
                        File.WriteAllBytes(sfd.FileName,Data[key]);
                        main.Invoke((MethodInvoker)(() => dialog.Close()));
                    }
                    catch (Exception ex)
                    {
                        main.Invoke((MethodInvoker)(() => dialog.Close()));
                        MessageBox.Show(ex.Message + "\n\nDetailed Error:\n" + ex, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }).Start();
                dialog.ShowDialog();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) => DeleteFile();
        private void AsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TextViewer{Key = listViewMain.SelectedItems[0].Text, 
                Text = listViewMain.SelectedItems[0].Text,Index = listViewMain.SelectedItems[0].Index,
                Lv = listViewMain}
                .Show(this);
        }
        private void AsPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PhotoViewer{Key = listViewMain.SelectedItems[0].Text}.Show(this);
        }
        #endregion

        /// <summary>
        /// Delete the selected item in list view
        /// </summary>
        private void DeleteFile()
        {
            if(listViewMain.SelectedItems.Count == 0)//Nothing to delete
                return;
            LoadingForm dialog = new LoadingForm {labelMain = {Text = "Deleting File. Please Wait..."}};
            Main main = this;
            string key = listViewMain.SelectedItems[0].Text;
            new Task(() =>
            {
                ZeroArray(key);
                Data.Remove(key); //Remove from ram
                listViewMain.Invoke((MethodInvoker)(()=>listViewMain.Items.RemoveAt(listViewMain.SelectedItems[0].Index))); //Remove from list
                if (Properties.Settings.Default.GCAfterDelete) //Run GC
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                main.Invoke((MethodInvoker)(() => dialog.Close()));
            }).Start();
            dialog.ShowDialog();
        }
        /// <summary>
        /// Writes zero to the array. This is in another scope to make sure GC collects everything
        /// </summary>
        /// <param name="key">The key in array</param>
        private static void ZeroArray(string key)
        {
            if (Properties.Settings.Default.RewriteDataByZero) //If true at first writes zero to array
                Array.Clear(Data[key], 0, Data[key].Length);
        }
    }

}

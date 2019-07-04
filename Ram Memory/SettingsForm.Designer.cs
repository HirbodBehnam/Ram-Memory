namespace Ram_Memory
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.checkBoxGC = new System.Windows.Forms.CheckBox();
            this.checkBoxSecureDelete = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxGC
            // 
            this.checkBoxGC.AutoSize = true;
            this.checkBoxGC.Location = new System.Drawing.Point(12, 12);
            this.checkBoxGC.Name = "checkBoxGC";
            this.checkBoxGC.Size = new System.Drawing.Size(209, 17);
            this.checkBoxGC.TabIndex = 0;
            this.checkBoxGC.Text = "Run garbage clearner after deleting file";
            this.checkBoxGC.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecureDelete
            // 
            this.checkBoxSecureDelete.AutoSize = true;
            this.checkBoxSecureDelete.Location = new System.Drawing.Point(12, 35);
            this.checkBoxSecureDelete.Name = "checkBoxSecureDelete";
            this.checkBoxSecureDelete.Size = new System.Drawing.Size(223, 17);
            this.checkBoxSecureDelete.TabIndex = 1;
            this.checkBoxSecureDelete.Text = "Rewrite all bytes to zero before delocating";
            this.checkBoxSecureDelete.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(164, 105);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(83, 105);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 140);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxSecureDelete);
            this.Controls.Add(this.checkBoxGC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxGC;
        private System.Windows.Forms.CheckBox checkBoxSecureDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
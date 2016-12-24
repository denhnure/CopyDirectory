namespace CopyDirectory
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CopyFiles = new System.Windows.Forms.Button();
            this.copiedFilesListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.destinationFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Choose source folder ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.sourceFolderButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Choose destination folder...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.destinationFolderButton_Click);
            // 
            // CopyFiles
            // 
            this.CopyFiles.Enabled = false;
            this.CopyFiles.Location = new System.Drawing.Point(556, 92);
            this.CopyFiles.Name = "CopyFiles";
            this.CopyFiles.Size = new System.Drawing.Size(75, 23);
            this.CopyFiles.TabIndex = 5;
            this.CopyFiles.Text = "Copy files";
            this.CopyFiles.UseVisualStyleBackColor = true;
            this.CopyFiles.Click += new System.EventHandler(this.copyFiles_Click);
            // 
            // copiedFilesListBox
            // 
            this.copiedFilesListBox.FormattingEnabled = true;
            this.copiedFilesListBox.Location = new System.Drawing.Point(19, 135);
            this.copiedFilesListBox.Name = "copiedFilesListBox";
            this.copiedFilesListBox.Size = new System.Drawing.Size(612, 277);
            this.copiedFilesListBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Copied files";
            // 
            // sourceFolderPathTextBox
            // 
            this.sourceFolderPathTextBox.Location = new System.Drawing.Point(19, 24);
            this.sourceFolderPathTextBox.Name = "sourceFolderPathTextBox";
            this.sourceFolderPathTextBox.Size = new System.Drawing.Size(443, 20);
            this.sourceFolderPathTextBox.TabIndex = 8;
            this.sourceFolderPathTextBox.TextChanged += new System.EventHandler(this.sourceFolderPathTextBox_TextChanged);
            // 
            // destinationFolderPathTextBox
            // 
            this.destinationFolderPathTextBox.Location = new System.Drawing.Point(19, 53);
            this.destinationFolderPathTextBox.Name = "destinationFolderPathTextBox";
            this.destinationFolderPathTextBox.Size = new System.Drawing.Size(443, 20);
            this.destinationFolderPathTextBox.TabIndex = 9;
            this.destinationFolderPathTextBox.TextChanged += new System.EventHandler(this.destinationFolderPathTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 626);
            this.Controls.Add(this.destinationFolderPathTextBox);
            this.Controls.Add(this.sourceFolderPathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copiedFilesListBox);
            this.Controls.Add(this.CopyFiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CopyFiles;
        private System.Windows.Forms.ListBox copiedFilesListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sourceFolderPathTextBox;
        private System.Windows.Forms.TextBox destinationFolderPathTextBox;
    }
}


using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sourceFolderButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (IsPathEntered(folderBrowserDialog.SelectedPath))
            {
                sourceFolderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void destinationFolderButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (IsPathEntered(folderBrowserDialog.SelectedPath))
            {
                destinationFolderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void sourceFolderPathTextBox_TextChanged(object sender, EventArgs e)
        {
            CopyFiles.Enabled = AreSourceAndDestinationFoldersSet();
        }

        private void destinationFolderPathTextBox_TextChanged(object sender, EventArgs e)
        {
            CopyFiles.Enabled = AreSourceAndDestinationFoldersSet();
        }

        private bool AreSourceAndDestinationFoldersSet()
        {
            return IsPathEntered(sourceFolderPathTextBox.Text) && IsPathEntered(destinationFolderPathTextBox.Text);
        }

        private bool IsPathEntered(string path)
        {
            return !string.IsNullOrWhiteSpace(path);
        }

        private void copyFiles_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<string>(ReportProgress);

            CopyFiles.Enabled = false;

            Task.Run(() =>
            {
                var copy = new Core.CopyDirectory(progressIndicator);
                copy.Copy(sourceFolderPathTextBox.Text, destinationFolderPathTextBox.Text);
            }).ContinueWith(previousTask =>
            {
                HandleExceptions(previousTask);
                UpdateCopyButtonStateFromMainThread();
            });
        }

        private void ReportProgress(string fileName)
        {
            copiedFilesListBox.Items.Add(fileName);
        }

        private static void HandleExceptions(Task previousTask)
        {
            if (previousTask.Status == TaskStatus.Faulted)
            {
                var exception = previousTask.Exception;

                if (exception != null)
                {
                    foreach (var innerException in exception.InnerExceptions)
                    {
                        MessageBox.Show(innerException.Message);
                    }
                }
            }
        }

        private void UpdateCopyButtonStateFromMainThread()
        {
            Invoke((MethodInvoker)delegate { CopyFiles.Enabled = true; });
        }
    }
}

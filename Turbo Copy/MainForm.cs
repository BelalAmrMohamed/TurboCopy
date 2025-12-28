//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Reflection;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Turbo_Copy
//{
//    public partial class MainForm : Form
//    {
//        private int totalFiles = 0;
//        private int processedFiles = 0;

//        public MainForm()
//        {
//            InitializeComponent();
//        }

//        private void BtnBrowseSource_Click(object sender, EventArgs e)
//        {
//            string selected = SelectFolderModern("Select Source Folder");
//            if (!string.IsNullOrEmpty(selected))
//            {
//                txtSource.Text = selected;
//                ValidatePaths();
//            }
//        }

//        private void BtnBrowseDest_Click(object sender, EventArgs e)
//        {
//            string selected = SelectFolderModern("Select Destination Folder");
//            if (!string.IsNullOrEmpty(selected))
//            {
//                txtDest.Text = selected;
//                ValidatePaths();
//            }
//        }

//        private string SelectFolderModern(string description)
//        {
//            // Use Vista-style folder dialog with reflection
//            try
//            {
//                Type shellFileDialogType = Type.GetType("System.Windows.Forms.FileDialogNative+IFileDialog, System.Windows.Forms");
//                if (shellFileDialogType != null)
//                {
//                    // Try using the Vista-style dialog via reflection
//                    return SelectFolderVista(description);
//                }
//            }
//            catch { }

//            // Fallback: Use OpenFileDialog trick for modern look
//            return SelectFolderWithOpenFileDialog(description);
//        }

//        private string SelectFolderVista(string description)
//        {
//            var dialog = new FolderBrowserDialog();
//            dialog.Description = description;
//            dialog.ShowNewFolderButton = true;

//            // Use reflection to enable Vista-style dialog
//            try
//            {
//                Type dialogType = dialog.GetType();
//                PropertyInfo autoupgradeProp = dialogType.GetProperty("AutoUpgradeEnabled",
//                    BindingFlags.NonPublic | BindingFlags.Instance);
//                if (autoupgradeProp != null)
//                {
//                    autoupgradeProp.SetValue(dialog, true, null);
//                }
//            }
//            catch { }

//            if (dialog.ShowDialog() == DialogResult.OK)
//            {
//                return dialog.SelectedPath;
//            }

//            return string.Empty;
//        }

//        private string SelectFolderWithOpenFileDialog(string description)
//        {
//            using (var dialog = new OpenFileDialog())
//            {
//                dialog.Title = description;
//                dialog.Filter = "Folders|*.none";
//                dialog.CheckFileExists = false;
//                dialog.CheckPathExists = true;
//                dialog.FileName = "Select Folder";

//                // Use InitialDirectory if we have a valid path
//                if (description.Contains("Source") && Directory.Exists(txtSource.Text))
//                    dialog.InitialDirectory = txtSource.Text;
//                else if (description.Contains("Destination") && Directory.Exists(txtDest.Text))
//                    dialog.InitialDirectory = txtDest.Text;

//                if (dialog.ShowDialog() == DialogResult.OK)
//                {
//                    return Path.GetDirectoryName(dialog.FileName);
//                }
//            }
//            return string.Empty;
//        }

//        private void ValidatePaths()
//        {
//            bool sourceValid = Directory.Exists(txtSource.Text);
//            bool destValid = !string.IsNullOrEmpty(txtDest.Text);

//            // Visual feedback
//            txtSource.BackColor = string.IsNullOrEmpty(txtSource.Text) ?
//                System.Drawing.SystemColors.Window :
//                (sourceValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral);

//            txtDest.BackColor = string.IsNullOrEmpty(txtDest.Text) ?
//                System.Drawing.SystemColors.Window : System.Drawing.Color.LightYellow;
//        }

//        private async void BtnStart_Click(object sender, EventArgs e)
//        {
//            string source = txtSource.Text.Trim();
//            string dest = txtDest.Text.Trim();

//            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest))
//            {
//                MessageBox.Show("Please define both paths.", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (!Directory.Exists(source))
//            {
//                MessageBox.Show("Source path does not exist!", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Confirm if destination exists and user chose Cut/Move
//            if (rbMove.Checked)
//            {
//                var result = MessageBox.Show(
//                    "You are about to MOVE files/folders. This will DELETE them from the source. Continue?",
//                    "Confirm Move Operation",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result != DialogResult.Yes)
//                    return;
//            }

//            // FIX: Adjust destination to include source folder name
//            // This ensures the folder itself is moved, not just its contents
//            string sourceFolderName = new DirectoryInfo(source).Name;
//            string adjustedDest = Path.Combine(dest, sourceFolderName);

//            // Determine arguments
//            string modeFlag = rbMove.Checked ? "/MOVE" : "";
//            string arguments = $"\"{source}\" \"{adjustedDest}\" /E /MT:32 /NP /NDL /NFL {modeFlag}";

//            // Reset progress tracking
//            totalFiles = 0;
//            processedFiles = 0;

//            // Toggle UI
//            btnStart.Enabled = false;
//            btnBrowseSource.Enabled = false;
//            btnBrowseDest.Enabled = false;
//            rbCopy.Enabled = false;
//            rbMove.Enabled = false;

//            rtbLog.Clear();
//            progressBar.Value = 0;
//            progressBar.Visible = true;
//            lblProgress.Visible = true;
//            lblProgress.Text = "Initializing...";
//            lblStatus.Text = "Transferring...";

//            await Task.Run(() => RunRobocopy(arguments));

//            // Complete
//            progressBar.Value = 100;
//            lblProgress.Text = "Complete!";
//            lblStatus.Text = "Finished.";

//            await Task.Delay(1000);

//            progressBar.Visible = false;
//            lblProgress.Visible = false;

//            // Re-enable UI
//            btnStart.Enabled = true;
//            btnBrowseSource.Enabled = true;
//            btnBrowseDest.Enabled = true;
//            rbCopy.Enabled = true;
//            rbMove.Enabled = true;

//            string operationText = rbMove.Checked ? "moved" : "copied";
//            MessageBox.Show($"Operation Completed!\n\nFolder '{sourceFolderName}' {operationText} to:\n{adjustedDest}\n\nFiles processed: {processedFiles}",
//                "Turbo Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void RunRobocopy(string args)
//        {
//            ProcessStartInfo psi = new ProcessStartInfo
//            {
//                FileName = "robocopy.exe",
//                Arguments = args,
//                RedirectStandardOutput = true,
//                UseShellExecute = false,
//                CreateNoWindow = true
//            };

//            using (Process p = new Process { StartInfo = psi })
//            {
//                p.OutputDataReceived += (sender, line) =>
//                {
//                    if (line.Data != null)
//                    {
//                        // Parse the output for progress
//                        ParseRobocopyOutput(line.Data);

//                        // Safely update UI from background thread
//                        this.BeginInvoke(new Action(() =>
//                        {
//                            rtbLog.AppendText(line.Data + Environment.NewLine);
//                            rtbLog.SelectionStart = rtbLog.Text.Length;
//                            rtbLog.ScrollToCaret();
//                        }));
//                    }
//                };

//                p.Start();
//                p.BeginOutputReadLine();
//                p.WaitForExit();
//            }
//        }

//        private void ParseRobocopyOutput(string output)
//        {
//            try
//            {
//                // Look for percentage completion (e.g., "  50%")
//                var percentMatch = Regex.Match(output, @"\s+(\d+)%");
//                if (percentMatch.Success)
//                {
//                    int percent = int.Parse(percentMatch.Groups[1].Value);
//                    UpdateProgress(percent, $"Progress: {percent}%");
//                    return;
//                }

//                // Look for "Dirs" and "Files" in summary
//                var filesMatch = Regex.Match(output, @"Files\s*:\s*(\d+)", RegexOptions.IgnoreCase);
//                if (filesMatch.Success)
//                {
//                    totalFiles = int.Parse(filesMatch.Groups[1].Value);
//                    UpdateProgress(-1, $"Found {totalFiles} files to process...");
//                    return;
//                }

//                // Count copied/moved files
//                if (output.Contains("New File") || output.Contains("Newer") ||
//                    output.Contains("older") || (output.Contains("100%") && output.Trim().EndsWith("%")))
//                {
//                    processedFiles++;
//                    if (totalFiles > 0)
//                    {
//                        int percent = Math.Min(100, (processedFiles * 100) / totalFiles);
//                        UpdateProgress(percent, $"Processing: {processedFiles}/{totalFiles} files ({percent}%)");
//                    }
//                }
//            }
//            catch
//            {
//                // Ignore parsing errors
//            }
//        }

//        private void UpdateProgress(int percent, string message)
//        {
//            this.BeginInvoke(new Action(() =>
//            {
//                if (percent >= 0)
//                {
//                    progressBar.Value = Math.Min(100, percent);
//                }
//                lblProgress.Text = message;
//                lblStatus.Text = message;
//            }));
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO = System.IO;

namespace Turbo_Copy
{
    public partial class MainForm : Form
    {
        private int totalFiles = 0;
        private int processedFiles = 0;
        private long totalBytes = 0;
        private long processedBytes = 0;
        private DateTime startTime;
        private CancellationTokenSource cancellationToken;
        private Process currentProcess;
        private List<string> selectedFiles = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            UpdateBrowseButtonText();
        }

        private void RbSourceType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBrowseButtonText();
            txtSource.Clear();
            selectedFiles.Clear();
            lblFileInfo.Text = "";
        }

        private void UpdateBrowseButtonText()
        {
            if (rbFile.Checked)
            {
                btnBrowseSource.Text = "📄 Browse...";
                label1.Text = "Source File(s):";
            }
            else
            {
                btnBrowseSource.Text = "📁 Browse...";
                label1.Text = "Source Folder:";
            }
        }

        private void BtnBrowseSource_Click(object sender, EventArgs e)
        {
            if (rbFile.Checked)
            {
                // File mode - use OpenFileDialog with multi-select
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Select File(s) to Copy/Move";
                    dialog.Filter = "All Files (*.*)|*.*";
                    dialog.Multiselect = true;
                    dialog.CheckFileExists = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFiles = dialog.FileNames.ToList();
                        if (selectedFiles.Count == 1)
                        {
                            txtSource.Text = selectedFiles[0];
                            lblFileInfo.Text = $"Selected: 1 file ({FormatBytes(new IO.FileInfo(selectedFiles[0]).Length)})";
                        }
                        else
                        {
                            txtSource.Text = $"{selectedFiles.Count} files selected";
                            long totalSize = selectedFiles.Sum(f => new IO.FileInfo(f).Length);
                            lblFileInfo.Text = $"Selected: {selectedFiles.Count} files ({FormatBytes(totalSize)})";
                        }
                        ValidatePaths();
                    }
                }
            }
            else
            {
                // Folder mode
                string selected = SelectFolderModern("Select Source Folder");
                if (!string.IsNullOrEmpty(selected))
                {
                    txtSource.Text = selected;
                    selectedFiles.Clear();
                    lblFileInfo.Text = "";
                    ValidatePaths();
                }
            }
        }

        private void BtnBrowseDest_Click(object sender, EventArgs e)
        {
            string selected = SelectFolderModern("Select Destination Folder");
            if (!string.IsNullOrEmpty(selected))
            {
                txtDest.Text = selected;
                ValidatePaths();
            }
        }

        private string SelectFolderModern(string description)
        {
            // Use OpenFileDialog trick for modern look
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = description;
                dialog.ShowNewFolderButton = true;

                // Enable Vista-style dialog via reflection
                try
                {
                    Type dialogType = dialog.GetType();
                    PropertyInfo autoupgradeProp = dialogType.GetProperty("AutoUpgradeEnabled",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    if (autoupgradeProp != null)
                    {
                        autoupgradeProp.SetValue(dialog, true, null);
                    }
                }
                catch { }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            return string.Empty;
        }

        private void ValidatePaths()
        {
            bool sourceValid = false;

            if (rbFile.Checked)
            {
                sourceValid = selectedFiles.Count > 0 && selectedFiles.All(f => IO.File.Exists(f));
            }
            else
            {
                sourceValid = IO.Directory.Exists(txtSource.Text);
            }

            bool destValid = !string.IsNullOrEmpty(txtDest.Text);

            // Visual feedback
            txtSource.BackColor = string.IsNullOrEmpty(txtSource.Text) ?
                System.Drawing.SystemColors.Window :
                (sourceValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral);

            txtDest.BackColor = string.IsNullOrEmpty(txtDest.Text) ?
                System.Drawing.SystemColors.Window : System.Drawing.Color.LightYellow;
        }

        private void BtnClearSource_Click(object sender, EventArgs e)
        {
            txtSource.Clear();
            selectedFiles.Clear();
            lblFileInfo.Text = "";
            ValidatePaths();
        }

        private void BtnClearDest_Click(object sender, EventArgs e)
        {
            txtDest.Clear();
            ValidatePaths();
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            string dest = txtDest.Text.Trim();

            if (string.IsNullOrEmpty(dest))
            {
                MessageBox.Show("Please define destination path.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate source
            if (rbFile.Checked)
            {
                if (selectedFiles.Count == 0)
                {
                    MessageBox.Show("Please select file(s) to transfer.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!selectedFiles.All(f => IO.File.Exists(f)))
                {
                    MessageBox.Show("One or more selected files no longer exist!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                string source = txtSource.Text.Trim();
                if (string.IsNullOrEmpty(source) || !IO.Directory.Exists(source))
                {
                    MessageBox.Show("Source folder does not exist!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Confirm move operation
            if (rbMove.Checked)
            {
                var result = MessageBox.Show(
                    "You are about to MOVE files/folders. This will DELETE them from the source. Continue?",
                    "Confirm Move Operation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            // Reset progress tracking
            totalFiles = 0;
            processedFiles = 0;
            totalBytes = 0;
            processedBytes = 0;
            startTime = DateTime.Now;
            cancellationToken = new CancellationTokenSource();

            // Toggle UI
            SetUIState(false);

            rtbLog.Clear();
            progressBar.Value = 0;
            progressBar.Visible = true;
            lblProgress.Visible = true;
            lblProgress.Text = "Initializing...";
            lblStatus.Text = "Transferring...";
            btnCancel.Visible = true;
            btnCancel.Enabled = true;

            try
            {
                if (rbFile.Checked)
                {
                    await Task.Run(() => TransferFiles(dest, cancellationToken.Token));
                }
                else
                {
                    string source = txtSource.Text.Trim();
                    await Task.Run(() => TransferFolder(source, dest, cancellationToken.Token));
                }

                if (!cancellationToken.Token.IsCancellationRequested)
                {
                    progressBar.Value = 100;
                    lblProgress.Text = "Complete!";
                    lblStatus.Text = "Finished.";

                    await Task.Delay(1000);

                    string operationText = rbMove.Checked ? "moved" : "copied";
                    MessageBox.Show(
                        $"Operation Completed!\n\n" +
                        $"Files processed: {processedFiles}\n" +
                        $"Total size: {FormatBytes(processedBytes)}\n" +
                        $"Time elapsed: {(DateTime.Now - startTime).TotalSeconds:F1}s",
                        "Turbo Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operation cancelled by user.", "Cancelled",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during operation:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                lblProgress.Visible = false;
                btnCancel.Visible = false;
                SetUIState(true);
            }
        }

        private void TransferFiles(string destFolder, CancellationToken token)
        {
            totalFiles = selectedFiles.Count;
            processedFiles = 0;

            foreach (string sourceFile in selectedFiles)
            {
                if (token.IsCancellationRequested)
                    break;

                try
                {
                    string fileName = IO.Path.GetFileName(sourceFile);
                    string destFile = IO.Path.Combine(destFolder, fileName);

                    // Skip if exists and user chose to skip
                    if (chkSkipExisting.Checked && IO.File.Exists(destFile))
                    {
                        LogMessage($"Skipped: {fileName} (already exists)");
                        processedFiles++;
                        continue;
                    }

                    // Ensure destination directory exists
                    IO.Directory.CreateDirectory(destFolder);

                    IO.FileInfo fileInfo = new IO.FileInfo(sourceFile);
                    long fileSize = fileInfo.Length;

                    LogMessage($"Transferring: {fileName} ({FormatBytes(fileSize)})");

                    if (rbMove.Checked)
                    {
                        IO.File.Move(sourceFile, destFile);
                    }
                    else
                    {
                        IO.File.Copy(sourceFile, destFile, true);
                    }

                    // Verify if requested
                    if (chkVerify.Checked && rbCopy.Checked)
                    {
                        if (VerifyFile(sourceFile, destFile))
                        {
                            LogMessage($"✓ Verified: {fileName}");
                        }
                        else
                        {
                            LogMessage($"⚠ Verification failed: {fileName}", true);
                        }
                    }

                    processedFiles++;
                    processedBytes += fileSize;

                    int percent = (processedFiles * 100) / totalFiles;
                    UpdateProgress(percent, $"Processing: {processedFiles}/{totalFiles} files ({percent}%)");
                    UpdateSpeed();
                }
                catch (Exception ex)
                {
                    LogMessage($"Error with {IO.Path.GetFileName(sourceFile)}: {ex.Message}", true);
                }
            }
        }

        private void TransferFolder(string source, string dest, CancellationToken token)
        {
            // Adjust destination to include source folder name
            string sourceFolderName = new IO.DirectoryInfo(source).Name;
            string adjustedDest = IO.Path.Combine(dest, sourceFolderName);

            // Build Robocopy arguments
            string modeFlag = rbMove.Checked ? "/MOVE" : "";
            string verifyFlag = chkVerify.Checked ? "/V" : "";
            string skipFlag = chkSkipExisting.Checked ? "/XO" : "";

            string arguments = $"\"{source}\" \"{adjustedDest}\" /E /MT:32 /NP {modeFlag} {verifyFlag} {skipFlag}";

            RunRobocopy(arguments, token);
        }

        private void RunRobocopy(string args, CancellationToken token)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "robocopy.exe",
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (currentProcess = new Process { StartInfo = psi })
            {
                currentProcess.OutputDataReceived += (sender, line) =>
                {
                    if (line.Data != null && !token.IsCancellationRequested)
                    {
                        ParseRobocopyOutput(line.Data);

                        this.BeginInvoke(new Action(() =>
                        {
                            rtbLog.AppendText(line.Data + Environment.NewLine);
                            rtbLog.SelectionStart = rtbLog.Text.Length;
                            rtbLog.ScrollToCaret();
                        }));
                    }
                };

                currentProcess.Start();
                currentProcess.BeginOutputReadLine();

                // Wait with cancellation support
                while (!currentProcess.WaitForExit(500))
                {
                    if (token.IsCancellationRequested)
                    {
                        try
                        {
                            currentProcess.Kill();
                            LogMessage("Transfer cancelled by user.", true);
                        }
                        catch { }
                        break;
                    }
                }
            }
        }

        private bool VerifyFile(string source, string dest)
        {
            try
            {
                IO.FileInfo sourceInfo = new IO.FileInfo(source);
                IO.FileInfo destInfo = new IO.FileInfo(dest);
                return sourceInfo.Length == destInfo.Length;
            }
            catch
            {
                return false;
            }
        }

        private void ParseRobocopyOutput(string output)
        {
            try
            {
                var percentMatch = Regex.Match(output, @"\s+(\d+)%");
                if (percentMatch.Success)
                {
                    int percent = int.Parse(percentMatch.Groups[1].Value);
                    UpdateProgress(percent, $"Progress: {percent}%");
                    return;
                }

                var filesMatch = Regex.Match(output, @"Files\s*:\s*(\d+)", RegexOptions.IgnoreCase);
                if (filesMatch.Success)
                {
                    totalFiles = int.Parse(filesMatch.Groups[1].Value);
                    UpdateProgress(-1, $"Found {totalFiles} files to process...");
                    return;
                }

                var bytesMatch = Regex.Match(output, @"Bytes\s*:\s*([\d.]+\s*[kmgt]?)", RegexOptions.IgnoreCase);
                if (bytesMatch.Success)
                {
                    totalBytes = ParseBytes(bytesMatch.Groups[1].Value);
                }

                if (output.Contains("New File") || output.Contains("Newer") ||
                    output.Contains("older") || (output.Contains("100%") && output.Trim().EndsWith("%")))
                {
                    processedFiles++;
                    if (totalFiles > 0)
                    {
                        int percent = Math.Min(100, (processedFiles * 100) / totalFiles);
                        UpdateProgress(percent, $"Processing: {processedFiles}/{totalFiles} files ({percent}%)");
                        UpdateSpeed();
                    }
                }
            }
            catch { }
        }

        private long ParseBytes(string bytesStr)
        {
            try
            {
                bytesStr = bytesStr.Trim().ToLower();
                double value = double.Parse(Regex.Match(bytesStr, @"[\d.]+").Value);

                if (bytesStr.Contains("k")) return (long)(value * 1024);
                if (bytesStr.Contains("m")) return (long)(value * 1024 * 1024);
                if (bytesStr.Contains("g")) return (long)(value * 1024 * 1024 * 1024);
                if (bytesStr.Contains("t")) return (long)(value * 1024 * 1024 * 1024 * 1024);

                return (long)value;
            }
            catch
            {
                return 0;
            }
        }

        private void UpdateProgress(int percent, string message)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (percent >= 0)
                {
                    progressBar.Value = Math.Min(100, percent);
                }
                lblProgress.Text = message;
                lblStatus.Text = message;
            }));
        }

        private void UpdateSpeed()
        {
            this.BeginInvoke(new Action(() =>
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                if (elapsed.TotalSeconds > 0 && processedBytes > 0)
                {
                    double bytesPerSecond = processedBytes / elapsed.TotalSeconds;
                    lblSpeed.Text = $"⚡ {FormatBytes((long)bytesPerSecond)}/s";
                }
            }));
        }

        private void LogMessage(string message, bool isError = false)
        {
            this.BeginInvoke(new Action(() =>
            {
                rtbLog.SelectionStart = rtbLog.Text.Length;
                rtbLog.SelectionColor = isError ? System.Drawing.Color.Orange : System.Drawing.Color.LightGray;
                rtbLog.AppendText(message + Environment.NewLine);
                rtbLog.ScrollToCaret();
            }));
        }

        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void SetUIState(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnBrowseSource.Enabled = enabled;
            btnBrowseDest.Enabled = enabled;
            rbCopy.Enabled = enabled;
            rbMove.Enabled = enabled;
            rbFile.Enabled = enabled;
            rbFolder.Enabled = enabled;
            chkVerify.Enabled = enabled;
            chkSkipExisting.Enabled = enabled;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (cancellationToken != null && !cancellationToken.IsCancellationRequested)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to cancel the operation?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cancellationToken.Cancel();
                    btnCancel.Enabled = false;
                    lblStatus.Text = "Cancelling...";
                }
            }
        }

        // Drag and Drop Support
        private void TxtSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void TxtSource_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                if (IO.File.Exists(files[0]))
                {
                    rbFile.Checked = true;
                    selectedFiles = files.ToList();
                    if (files.Length == 1)
                    {
                        txtSource.Text = files[0];
                        lblFileInfo.Text = $"Selected: 1 file ({FormatBytes(new IO.FileInfo(files[0]).Length)})";
                    }
                    else
                    {
                        txtSource.Text = $"{files.Length} files selected";
                        long totalSize = files.Sum(f => new IO.FileInfo(f).Length);
                        lblFileInfo.Text = $"Selected: {files.Length} files ({FormatBytes(totalSize)})";
                    }
                }
                else if (IO.Directory.Exists(files[0]))
                {
                    rbFolder.Checked = true;
                    txtSource.Text = files[0];
                    selectedFiles.Clear();
                    lblFileInfo.Text = "";
                }
                ValidatePaths();
            }
        }

        private void TxtDest_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void TxtDest_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && IO.Directory.Exists(files[0]))
            {
                txtDest.Text = files[0];
                ValidatePaths();
            }
        }
    }
}
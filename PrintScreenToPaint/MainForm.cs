// <copyright file="MainForm.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace PrintScreenToPaint
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Microsoft.Win32;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The save image count.
        /// </summary>
        private int saveImageCount = 0;

        /// <summary>
        /// The settings file path.
        /// </summary>
        private string settingsFilePath = "PrintScreenToPaint_SettingsData.txt";

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = new SettingsData();

        /// <summary>
        /// The assembly version.
        /// </summary>
        private Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// The semantic version.
        /// </summary>
        private string semanticVersion = string.Empty;

        /// <summary>
        /// The associated icon.
        /// </summary>
        private Icon associatedIcon = null;

        /// <summary>
        /// The friendly name of the program.
        /// </summary>
        private string friendlyName = "Print-screen to Paint";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrintScreenToPaint.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set notify icon
            this.mainNotifyIcon.Icon = this.Icon;

            // Set semantic version
            this.semanticVersion = this.assemblyVersion.Major + "." + this.assemblyVersion.Minor + "." + this.assemblyVersion.Build;

            // TODO Set current directory [can be made conditional to: args[1] == "/autostart"]
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            // Set the target key press event handler
            KeyboardHook.TargetKeyPress += this.OnTargetKeyPress;

            // Enable the keyboard hook
            KeyboardHook.EnableHook();

            /* Process settings */

            // Check for settings data file
            if (!File.Exists(this.settingsFilePath))
            {
                // Not present, assume first run and create it
                this.SaveSettingsData();

                // Inform user
                MessageBox.Show($"Created \"{this.settingsFilePath}\" file.{Environment.NewLine}Program icon will appear on system tray.{ Environment.NewLine}{Environment.NewLine}Press print-screen key to use the program!", "First run", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Process settings
            this.ProcessSettings();

            // Iterate image format menu items
            foreach (ToolStripMenuItem item in this.imageFormatToolStripMenuItem.DropDownItems)
            {
                // Check based on it being in current settings
                item.Checked = item.Text.Substring(1).ToLowerInvariant() == this.settingsData.SaveImageFormat;
            }
        }

        /// <summary>
        /// Handles the target key press event.
        /// </summary>
        private void OnTargetKeyPress()
        {
            // Set save image path
            string saveImagePath = Path.Combine(this.directoryTextBox.Text, $"{DateTime.Now.ToString("dd-MMMM-yyyy_hh-mm-sstt")}.{this.settingsData.SaveImageFormat}");

            // Save current screen to disk
            Rectangle rectangle = Screen.GetBounds(Point.Empty);

            // Use bitmap
            using (Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height))
            {
                // Use graphics
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Take screenshot
                    graphics.CopyFromScreen(Point.Empty, Point.Empty, rectangle.Size);
                }

                // Check for directory
                if (!Directory.Exists(this.directoryTextBox.Text))
                {
                    // Create directory
                    Directory.CreateDirectory(this.directoryTextBox.Text);
                }

                // Save screenshot to disk
                bitmap.Save(saveImagePath, this.GetImageFormat(this.settingsData.SaveImageFormat));

                // Raise saved image count
                this.saveImageCount++;

                // Reflect new image count
                this.countToolStripStatusLabel.Text = this.saveImageCount.ToString();
            }

            // Check if must open saved image
            if (!this.doNotopenImageToolStripMenuItem.Checked)
            {
                // Open screenshot in paint
                Process.Start($"mspaint", $"\"{saveImagePath.Replace("/", "\\")}\"");
            }
        }

        /// <summary>
        /// Gets the image format.
        /// </summary>
        /// <returns>The image format.</returns>
        /// <param name="passedSaveImageFormat">The passed save image format.</param>
        private ImageFormat GetImageFormat(string passedSaveImageFormat)
        {
            // Swith passed save image format string
            switch (passedSaveImageFormat.ToLower())
            {
                // PNG
                case "png":
                    return ImageFormat.Png;

                // JPEG
                case "jpg":
                    return ImageFormat.Jpeg;

                // BMP
                case "bmp":
                    return ImageFormat.Bmp;

                // GIF
                case "gif":
                    return ImageFormat.Gif;

                // TIFF
                case "tif":
                    return ImageFormat.Tiff;

                // TODO Can be extended to support other formats
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Handles the pause resume button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPauseResumeButtonClick(object sender, EventArgs e)
        {
            // Check if must pause
            if (this.pauseResumeButton.Text.StartsWith("&P", StringComparison.InvariantCulture))
            {
                // Disable keyboard hook
                KeyboardHook.DisableHook();

                // Update monitor status
                this.hotkeyGroupBox.Text = "Hotkey is: INACTIVE";

                // Set button text
                this.pauseResumeButton.Text = "&Resume";
            }
            else
            {
                // Enable keyboard hook
                KeyboardHook.EnableHook();

                // Update monitor status
                this.hotkeyGroupBox.Text = "Hotkey is: ACTIVE";

                // Set button text
                this.pauseResumeButton.Text = "&Pause";
            }
        }

        /// <summary>
        /// Saves the settings data.
        /// </summary>
        private void SaveSettingsData()
        {
            // Use stream writer
            using (StreamWriter streamWriter = new StreamWriter(this.settingsFilePath, false))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Serialize settings data
                xmlSerializer.Serialize(streamWriter, this.settingsData);
            }
        }

        /// <summary>
        /// Loads the settings data.
        /// </summary>
        /// <returns>The settings data.</returns>ing
        private SettingsData LoadSettingsData()
        {
            // Use file stream
            using (FileStream fileStream = File.OpenRead(this.settingsFilePath))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Return populated settings data
                return xmlSerializer.Deserialize(fileStream) as SettingsData;
            }
        }

        /// <summary>
        /// Processes the settings.
        /// </summary>
        private void ProcessSettings()
        {
            // Populate settings data
            this.settingsData = this.LoadSettingsData();

            // Set registry entry based on settings data
            this.ProcessRunAtStartupRegistry();

            // Set run at startup tool strip menu item check state
            this.runAtStartupToolStripMenuItem.Checked = this.settingsData.RunAtStartup;

            // Set hide close button menu item check state
            this.hideCloseButtonToolStripMenuItem.Checked = this.settingsData.HideCloseButton;

            // Set form's control box visibility
            this.ControlBox = !this.settingsData.HideCloseButton;

            // Set do not open image menu item check state
            this.doNotopenImageToolStripMenuItem.Checked = this.settingsData.DoNotOpenImage;

            // Check save image format
            foreach (ToolStripMenuItem item in this.imageFormatToolStripMenuItem.DropDownItems)
            {
                // Check based on it being the current format in settings
                item.Checked = item.Text.Substring(1).ToLowerInvariant() == this.settingsData.SaveImageFormat;
            }
        }

        /// <summary>
        /// Sends the program to the system tray.
        /// </summary>
        private void SendToSystemTray()
        {
            // Hide main form
            this.Hide();

            // Show notify icon 
            this.mainNotifyIcon.Visible = true;
        }

        /// <summary>
        /// Restores the window back from system tray to the foreground.
        /// </summary>
        private void RestoreFromSystemTray()
        {
            // Make form visible again
            this.Show();

            // Return window back to normal
            this.WindowState = FormWindowState.Normal;

            // Make it topmost
            this.TopMost = true;

            // Bring to the front of the Z-order
            this.BringToFront();

            // Reset topmost
            this.TopMost = false;

            // Hide system tray icon
            this.mainNotifyIcon.Visible = false;
        }

        /// <summary>
        /// Processes the run at startup registry action.
        /// </summary>
        private void ProcessRunAtStartupRegistry()
        {
            // Open registry key
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                // Check for run at startup in settings data
                if (this.settingsData.RunAtStartup)
                {
                    // Add app value
                    registryKey.SetValue(Application.ProductName, $"\"{Application.ExecutablePath}\" /autostart");
                }
                else
                {
                    // Check for app value
                    if (registryKey.GetValue(Application.ProductName) != null)
                    {
                        // Erase app value
                        registryKey.DeleteValue(Application.ProductName, false);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the browse button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            // Check for a valid directory
            if (Directory.Exists(this.directoryTextBox.Text))
            {
                // Set  folder browser dialog path
                this.folderBrowserDialog.SelectedPath = this.directoryTextBox.Text;
            }

            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Set directory
                this.directoryTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the headquarters patreon.com tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHeadquartersPatreoncomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open Patreon headquarters
            Process.Start("https://www.patreon.com/publicdomain");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub
            Process.Start("https://github.com/publicdomain");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread @ DonationCoder
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=49608.0");
        }

        /// <summary>
        /// Handles the about tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the new tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Ask user for a fresh start
            if (MessageBox.Show("Would you like to recreate a fresh start?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Reset settings
                this.settingsData = new SettingsData();

                // Save settings to disk
                this.SaveSettingsData();

                // Process settings
                this.ProcessSettings();

                // Check if must hit pause/resume button
                if (!this.pauseResumeButton.Text.StartsWith("&P", StringComparison.InvariantCulture))
                {
                    // Simulate click
                    this.pauseResumeButton.PerformClick();
                }

                // Reset image count
                this.saveImageCount = 0;

                // Reflect count in status
                this.countToolStripStatusLabel.Text = "0";
            }
        }

        /// <summary>
        /// Handles the minimize tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMinimizeToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Minimize program window
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles the exit tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close application
            this.Close();
        }

        /// <summary>
        /// Handles the main form form closing event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove hook
            KeyboardHook.DisableHook();

            // Set run at startup
            this.settingsData.RunAtStartup = this.runAtStartupToolStripMenuItem.Checked;

            // Process registry action
            this.ProcessRunAtStartupRegistry();

            // Set hide close button
            this.settingsData.HideCloseButton = this.hideCloseButtonToolStripMenuItem.Checked;

            // Set do not open image 
            this.settingsData.DoNotOpenImage = this.doNotopenImageToolStripMenuItem.Checked;

            // Save settings to disk
            this.SaveSettingsData();
        }

        /// <summary>
        /// Handles the image format tool strip menu item drop down item clicked event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnImageFormatToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Iterate items
            foreach (ToolStripMenuItem item in this.imageFormatToolStripMenuItem.DropDownItems)
            {
                // Check based on it being the clicked item
                item.Checked = item == e.ClickedItem;
            }

            // Update settings data
            this.settingsData.SaveImageFormat = e.ClickedItem.Text.Substring(1).ToLowerInvariant();
        }

        /// <summary>
        /// Handles the run at startup tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRunAtStartupToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Toggle run at startup check state
            this.runAtStartupToolStripMenuItem.Checked = !this.runAtStartupToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the do notopen image tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDoNotopenImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Toggle check state
            this.doNotopenImageToolStripMenuItem.Checked = !this.doNotopenImageToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the hide close button tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHideCloseButtonToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Toggle hide close button check box
            this.hideCloseButtonToolStripMenuItem.Checked = !this.hideCloseButtonToolStripMenuItem.Checked;

            // Set form's control box visibility
            this.ControlBox = !this.hideCloseButtonToolStripMenuItem.Checked;

            // Set control box visibility on settings data
            this.settingsData.HideCloseButton = this.hideCloseButtonToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the main form shown event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormShown(object sender, EventArgs e)
        {
            // Minimize program window
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles the main form resize event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormResize(object sender, EventArgs e)
        {
            // Check for minimized state
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Send to the system tray
                this.SendToSystemTray();
            }
        }

        /// <summary>
        /// Handles the show tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnShowToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Restore window
            this.RestoreFromSystemTray();
        }

        /// <summary>
        /// Handles the main notify icon mouse click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Mouse event arguments.</param>
        private void OnMainNotifyIconMouseClick(object sender, MouseEventArgs e)
        {
            // Check for left click
            if (e.Button == MouseButtons.Left)
            {
                // Restore window 
                this.RestoreFromSystemTray();
            }
        }
    }
}
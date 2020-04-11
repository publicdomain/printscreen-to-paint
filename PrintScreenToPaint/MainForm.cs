﻿// <copyright file="MainForm.cs" company="PublicDomain.com">
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
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The save image format.
        /// </summary>
        private ImageFormat saveImageFormat = ImageFormat.Png;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrintScreenToPaint.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set the target key press event handler
            KeyboardHook.TargetKeyPress += this.OnTargetKeyPress;

            // Enable the keyboard hook
            KeyboardHook.EnableHook();
        }

        /// <summary>
        /// Handles the target key press event.
        /// </summary>
        private void OnTargetKeyPress()
        {
            // Set save image path
            string saveImagePath = Path.Combine(this.directoryTextBox.Text, $"{DateTime.Now.ToString("dd-MMMM-yyyy_hh-mm-sstt")}.{saveImageFormat.ToString()}");

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
                bitmap.Save(saveImagePath, this.saveImageFormat);
            }

            // Check if must open saved image
            if (!this.doNotopenImageToolStripMenuItem.Checked)
            {
                // Open screenshot in paint
                Process.Start($"mspaint", $"\"{saveImagePath.Replace("/", "\\")}\"");
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
            // TODO Add code
        }

        /// <summary>
        /// Handles the minimize tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMinimizeToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
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
        }

        /// <summary>
        /// Handles the image format tool strip menu item drop down item clicked event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnImageFormatToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the run at startup tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRunAtStartupToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the do notopen image tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDoNotopenImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the hide close button tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHideCloseButtonToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }
    }
}

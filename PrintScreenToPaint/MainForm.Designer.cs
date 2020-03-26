﻿// <copyright file="MainForm.Designer.cs" company="PublicDomain.com">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>
// <auto-generated />

namespace PrintScreenToPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.notifyExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.runAtStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.hideCloseButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.headquartersPatreoncomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.originalThreadDonationCodercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
        	this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.directoryGroupBox = new System.Windows.Forms.GroupBox();
        	this.hotkeyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.browseButton = new System.Windows.Forms.Button();
        	this.directoryTextBox = new System.Windows.Forms.TextBox();
        	this.hotkeyGroupBox = new System.Windows.Forms.GroupBox();
        	this.pauseResumeButton = new System.Windows.Forms.Button();
        	this.notifyContextMenuStrip.SuspendLayout();
        	this.mainMenuStrip.SuspendLayout();
        	this.mainStatusStrip.SuspendLayout();
        	this.mainTableLayoutPanel.SuspendLayout();
        	this.directoryGroupBox.SuspendLayout();
        	this.hotkeyTableLayoutPanel.SuspendLayout();
        	this.hotkeyGroupBox.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// notifyContextMenuStrip
        	// 
        	this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.showToolStripMenuItem,
        	        	        	this.notifyExitToolStripMenuItem});
        	this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
        	this.notifyContextMenuStrip.Size = new System.Drawing.Size(104, 48);
        	// 
        	// showToolStripMenuItem
        	// 
        	this.showToolStripMenuItem.Name = "showToolStripMenuItem";
        	this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
        	this.showToolStripMenuItem.Text = "&Show";
        	// 
        	// notifyExitToolStripMenuItem
        	// 
        	this.notifyExitToolStripMenuItem.Name = "notifyExitToolStripMenuItem";
        	this.notifyExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
        	this.notifyExitToolStripMenuItem.Text = "&Exit";
        	// 
        	// mainMenuStrip
        	// 
        	this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.optionsToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem,
        	        	        	this.minimizeToolStripMenuItem});
        	this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
        	this.mainMenuStrip.Name = "mainMenuStrip";
        	this.mainMenuStrip.Size = new System.Drawing.Size(284, 24);
        	this.mainMenuStrip.TabIndex = 8;
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newToolStripMenuItem,
        	        	        	this.toolStripSeparator3,
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "&File";
        	// 
        	// newToolStripMenuItem
        	// 
        	this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        	this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        	this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
        	this.newToolStripMenuItem.Text = "&New";
        	this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewToolStripMenuItemClick);
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(138, 6);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
        	this.exitToolStripMenuItem.Text = "E&xit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
        	// 
        	// optionsToolStripMenuItem
        	// 
        	this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.runAtStartupToolStripMenuItem,
        	        	        	this.hideCloseButtonToolStripMenuItem});
        	this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
        	this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
        	this.optionsToolStripMenuItem.Text = "&Options";
        	// 
        	// runAtStartupToolStripMenuItem
        	// 
        	this.runAtStartupToolStripMenuItem.Name = "runAtStartupToolStripMenuItem";
        	this.runAtStartupToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        	this.runAtStartupToolStripMenuItem.Text = "&Run at startup";
        	// 
        	// hideCloseButtonToolStripMenuItem
        	// 
        	this.hideCloseButtonToolStripMenuItem.Name = "hideCloseButtonToolStripMenuItem";
        	this.hideCloseButtonToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        	this.hideCloseButtonToolStripMenuItem.Text = "&Hide close button";
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.headquartersPatreoncomToolStripMenuItem,
        	        	        	this.sourceCodeGithubcomToolStripMenuItem,
        	        	        	this.toolStripSeparator1,
        	        	        	this.originalThreadDonationCodercomToolStripMenuItem,
        	        	        	this.toolStripSeparator2,
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// headquartersPatreoncomToolStripMenuItem
        	// 
        	this.headquartersPatreoncomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("headquartersPatreoncomToolStripMenuItem.Image")));
        	this.headquartersPatreoncomToolStripMenuItem.Name = "headquartersPatreoncomToolStripMenuItem";
        	this.headquartersPatreoncomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.headquartersPatreoncomToolStripMenuItem.Text = "Headquarters @ Patreon.com";
        	this.headquartersPatreoncomToolStripMenuItem.Click += new System.EventHandler(this.OnHeadquartersPatreoncomToolStripMenuItemClick);
        	// 
        	// sourceCodeGithubcomToolStripMenuItem
        	// 
        	this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
        	this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
        	this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.sourceCodeGithubcomToolStripMenuItem.Text = "Source code @ Github.com";
        	this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
        	// 
        	// originalThreadDonationCodercomToolStripMenuItem
        	// 
        	this.originalThreadDonationCodercomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadDonationCodercomToolStripMenuItem.Image")));
        	this.originalThreadDonationCodercomToolStripMenuItem.Name = "originalThreadDonationCodercomToolStripMenuItem";
        	this.originalThreadDonationCodercomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.originalThreadDonationCodercomToolStripMenuItem.Text = "&Original thread @ DonationCoder.com";
        	this.originalThreadDonationCodercomToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalThreadDonationCodercomToolStripMenuItemClick);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.aboutToolStripMenuItem.Text = "&About...";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
        	// 
        	// minimizeToolStripMenuItem
        	// 
        	this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.minimizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minimizeToolStripMenuItem.Image")));
        	this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
        	this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
        	// 
        	// mainStatusStrip
        	// 
        	this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.mainToolStripStatusLabel});
        	this.mainStatusStrip.Location = new System.Drawing.Point(0, 158);
        	this.mainStatusStrip.Name = "mainStatusStrip";
        	this.mainStatusStrip.Size = new System.Drawing.Size(284, 22);
        	this.mainStatusStrip.SizingGrip = false;
        	this.mainStatusStrip.TabIndex = 7;
        	// 
        	// mainToolStripStatusLabel
        	// 
        	this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
        	this.mainToolStripStatusLabel.Size = new System.Drawing.Size(200, 17);
        	this.mainToolStripStatusLabel.Text = "Monitoring for print-screen hotkey...";
        	// 
        	// mainNotifyIcon
        	// 
        	this.mainNotifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
        	this.mainNotifyIcon.Text = "Click to show Multilingual Word Counter";
        	// 
        	// mainTableLayoutPanel
        	// 
        	this.mainTableLayoutPanel.ColumnCount = 1;
        	this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mainTableLayoutPanel.Controls.Add(this.directoryGroupBox, 0, 1);
        	this.mainTableLayoutPanel.Controls.Add(this.hotkeyGroupBox, 0, 0);
        	this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
        	this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
        	this.mainTableLayoutPanel.RowCount = 2;
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
        	this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        	this.mainTableLayoutPanel.Size = new System.Drawing.Size(284, 134);
        	this.mainTableLayoutPanel.TabIndex = 9;
        	// 
        	// directoryGroupBox
        	// 
        	this.directoryGroupBox.Controls.Add(this.hotkeyTableLayoutPanel);
        	this.directoryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.directoryGroupBox.Location = new System.Drawing.Point(3, 83);
        	this.directoryGroupBox.Name = "directoryGroupBox";
        	this.directoryGroupBox.Size = new System.Drawing.Size(278, 48);
        	this.directoryGroupBox.TabIndex = 7;
        	this.directoryGroupBox.TabStop = false;
        	this.directoryGroupBox.Text = "Save directory:";
        	// 
        	// hotkeyTableLayoutPanel
        	// 
        	this.hotkeyTableLayoutPanel.ColumnCount = 2;
        	this.hotkeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.95588F));
        	this.hotkeyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.04412F));
        	this.hotkeyTableLayoutPanel.Controls.Add(this.browseButton, 1, 0);
        	this.hotkeyTableLayoutPanel.Controls.Add(this.directoryTextBox, 0, 0);
        	this.hotkeyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.hotkeyTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
        	this.hotkeyTableLayoutPanel.Name = "hotkeyTableLayoutPanel";
        	this.hotkeyTableLayoutPanel.RowCount = 1;
        	this.hotkeyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.hotkeyTableLayoutPanel.Size = new System.Drawing.Size(272, 29);
        	this.hotkeyTableLayoutPanel.TabIndex = 0;
        	// 
        	// browseButton
        	// 
        	this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.browseButton.Location = new System.Drawing.Point(195, 3);
        	this.browseButton.Name = "browseButton";
        	this.browseButton.Size = new System.Drawing.Size(74, 23);
        	this.browseButton.TabIndex = 2;
        	this.browseButton.Text = "Browse";
        	this.browseButton.UseVisualStyleBackColor = true;
        	this.browseButton.Click += new System.EventHandler(this.OnBrowseButtonClick);
        	// 
        	// directoryTextBox
        	// 
        	this.directoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.directoryTextBox.Location = new System.Drawing.Point(3, 3);
        	this.directoryTextBox.Multiline = true;
        	this.directoryTextBox.Name = "directoryTextBox";
        	this.directoryTextBox.Size = new System.Drawing.Size(186, 23);
        	this.directoryTextBox.TabIndex = 1;
        	// 
        	// hotkeyGroupBox
        	// 
        	this.hotkeyGroupBox.Controls.Add(this.pauseResumeButton);
        	this.hotkeyGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.hotkeyGroupBox.Location = new System.Drawing.Point(3, 3);
        	this.hotkeyGroupBox.Name = "hotkeyGroupBox";
        	this.hotkeyGroupBox.Size = new System.Drawing.Size(278, 74);
        	this.hotkeyGroupBox.TabIndex = 6;
        	this.hotkeyGroupBox.TabStop = false;
        	this.hotkeyGroupBox.Text = "Hotkey is: ACTIVE";
        	// 
        	// pauseResumeButton
        	// 
        	this.pauseResumeButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.pauseResumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.pauseResumeButton.Location = new System.Drawing.Point(3, 16);
        	this.pauseResumeButton.Name = "pauseResumeButton";
        	this.pauseResumeButton.Size = new System.Drawing.Size(272, 55);
        	this.pauseResumeButton.TabIndex = 0;
        	this.pauseResumeButton.Text = "&Pause";
        	this.pauseResumeButton.UseVisualStyleBackColor = true;
        	this.pauseResumeButton.Click += new System.EventHandler(this.OnPauseResumeButtonClick);
        	// 
        	// MainForm
        	// 
        	this.AcceptButton = this.pauseResumeButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(284, 180);
        	this.Controls.Add(this.mainTableLayoutPanel);
        	this.Controls.Add(this.mainMenuStrip);
        	this.Controls.Add(this.mainStatusStrip);
        	this.Name = "MainForm";
        	this.Text = "Print-screen to Paint";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
        	this.notifyContextMenuStrip.ResumeLayout(false);
        	this.mainMenuStrip.ResumeLayout(false);
        	this.mainMenuStrip.PerformLayout();
        	this.mainStatusStrip.ResumeLayout(false);
        	this.mainStatusStrip.PerformLayout();
        	this.mainTableLayoutPanel.ResumeLayout(false);
        	this.directoryGroupBox.ResumeLayout(false);
        	this.hotkeyTableLayoutPanel.ResumeLayout(false);
        	this.hotkeyTableLayoutPanel.PerformLayout();
        	this.hotkeyGroupBox.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TableLayoutPanel hotkeyTableLayoutPanel;
        private System.Windows.Forms.Button pauseResumeButton;
        private System.Windows.Forms.GroupBox hotkeyGroupBox;
        private System.Windows.Forms.GroupBox directoryGroupBox;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem originalThreadDonationCodercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headquartersPatreoncomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideCloseButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAtStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem notifyExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
    }
}
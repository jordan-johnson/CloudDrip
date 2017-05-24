namespace CloudDrip.Forms {
	partial class CloudDripForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloudDripForm));
			this.pathField = new System.Windows.Forms.TextBox();
			this.pathLabel = new System.Windows.Forms.Label();
			this.pathButton = new System.Windows.Forms.Button();
			this.urlField = new System.Windows.Forms.TextBox();
			this.urlLabel = new System.Windows.Forms.Label();
			this.pasteButton = new System.Windows.Forms.Button();
			this.downloadButton = new System.Windows.Forms.Button();
			this.footerVersion = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.dlProgressLabel = new System.Windows.Forms.Label();
			this.footerLink = new System.Windows.Forms.LinkLabel();
			this.coverArt = new System.Windows.Forms.PictureBox();
			this.dlProgressInfoTextbox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.coverArt)).BeginInit();
			this.SuspendLayout();
			// 
			// pathField
			// 
			this.pathField.Location = new System.Drawing.Point(12, 60);
			this.pathField.Name = "pathField";
			this.pathField.Size = new System.Drawing.Size(234, 20);
			this.pathField.TabIndex = 0;
			// 
			// pathLabel
			// 
			this.pathLabel.AutoSize = true;
			this.pathLabel.Location = new System.Drawing.Point(9, 44);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(133, 13);
			this.pathLabel.TabIndex = 1;
			this.pathLabel.Text = "Select path to save drips...";
			// 
			// pathButton
			// 
			this.pathButton.Location = new System.Drawing.Point(252, 59);
			this.pathButton.Name = "pathButton";
			this.pathButton.Size = new System.Drawing.Size(41, 23);
			this.pathButton.TabIndex = 2;
			this.pathButton.Text = "...";
			this.pathButton.UseVisualStyleBackColor = true;
			this.pathButton.Click += new System.EventHandler(this.browseDirectoryClicked);
			// 
			// urlField
			// 
			this.urlField.Location = new System.Drawing.Point(12, 110);
			this.urlField.Name = "urlField";
			this.urlField.Size = new System.Drawing.Size(234, 20);
			this.urlField.TabIndex = 4;
			// 
			// urlLabel
			// 
			this.urlLabel.AutoSize = true;
			this.urlLabel.Location = new System.Drawing.Point(9, 94);
			this.urlLabel.Name = "urlLabel";
			this.urlLabel.Size = new System.Drawing.Size(90, 13);
			this.urlLabel.TabIndex = 5;
			this.urlLabel.Text = "SoundCloud URL";
			// 
			// pasteButton
			// 
			this.pasteButton.Location = new System.Drawing.Point(252, 109);
			this.pasteButton.Name = "pasteButton";
			this.pasteButton.Size = new System.Drawing.Size(75, 23);
			this.pasteButton.TabIndex = 6;
			this.pasteButton.Text = "Paste";
			this.pasteButton.UseVisualStyleBackColor = true;
			this.pasteButton.Click += new System.EventHandler(this.pasteButtonClicked);
			// 
			// downloadButton
			// 
			this.downloadButton.Location = new System.Drawing.Point(333, 109);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(75, 23);
			this.downloadButton.TabIndex = 7;
			this.downloadButton.Text = "Download";
			this.downloadButton.UseVisualStyleBackColor = true;
			this.downloadButton.Click += new System.EventHandler(this.downloadButtonClicked);
			// 
			// footerVersion
			// 
			this.footerVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.footerVersion.AutoSize = true;
			this.footerVersion.Location = new System.Drawing.Point(9, 305);
			this.footerVersion.Name = "footerVersion";
			this.footerVersion.Size = new System.Drawing.Size(77, 13);
			this.footerVersion.TabIndex = 10;
			this.footerVersion.Text = "CloudDrip v1.1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(620, 24);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.optionsToolStripMenuItem.Text = "File";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Enabled = false;
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.importToolStripMenuItem.Text = "Import...";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences...";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.aboutToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 174);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(596, 23);
			this.progressBar.TabIndex = 12;
			// 
			// dlProgressLabel
			// 
			this.dlProgressLabel.AutoSize = true;
			this.dlProgressLabel.Location = new System.Drawing.Point(9, 158);
			this.dlProgressLabel.Name = "dlProgressLabel";
			this.dlProgressLabel.Size = new System.Drawing.Size(41, 13);
			this.dlProgressLabel.TabIndex = 13;
			this.dlProgressLabel.Text = "Ready.";
			// 
			// footerLink
			// 
			this.footerLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.footerLink.Location = new System.Drawing.Point(437, 300);
			this.footerLink.Name = "footerLink";
			this.footerLink.Size = new System.Drawing.Size(171, 23);
			this.footerLink.TabIndex = 14;
			this.footerLink.TabStop = true;
			this.footerLink.Text = "https://github.com/jordan-johnson";
			this.footerLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.footerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.footerLink_LinkClicked);
			// 
			// coverArt
			// 
			this.coverArt.Image = ((System.Drawing.Image)(resources.GetObject("coverArt.Image")));
			this.coverArt.Location = new System.Drawing.Point(516, 44);
			this.coverArt.Name = "coverArt";
			this.coverArt.Size = new System.Drawing.Size(92, 88);
			this.coverArt.TabIndex = 9;
			this.coverArt.TabStop = false;
			// 
			// dlProgressInfoTextbox
			// 
			this.dlProgressInfoTextbox.BackColor = System.Drawing.SystemColors.Control;
			this.dlProgressInfoTextbox.Location = new System.Drawing.Point(12, 203);
			this.dlProgressInfoTextbox.Multiline = true;
			this.dlProgressInfoTextbox.Name = "dlProgressInfoTextbox";
			this.dlProgressInfoTextbox.ReadOnly = true;
			this.dlProgressInfoTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dlProgressInfoTextbox.Size = new System.Drawing.Size(596, 94);
			this.dlProgressInfoTextbox.TabIndex = 15;
			// 
			// CloudDripForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 327);
			this.Controls.Add(this.dlProgressInfoTextbox);
			this.Controls.Add(this.footerLink);
			this.Controls.Add(this.dlProgressLabel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.footerVersion);
			this.Controls.Add(this.coverArt);
			this.Controls.Add(this.downloadButton);
			this.Controls.Add(this.pasteButton);
			this.Controls.Add(this.urlLabel);
			this.Controls.Add(this.urlField);
			this.Controls.Add(this.pathButton);
			this.Controls.Add(this.pathLabel);
			this.Controls.Add(this.pathField);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "CloudDripForm";
			this.Text = "CloudDrip";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.coverArt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox pathField;
		private System.Windows.Forms.Label pathLabel;
		private System.Windows.Forms.Button pathButton;
		private System.Windows.Forms.TextBox urlField;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.Button pasteButton;
		private System.Windows.Forms.Button downloadButton;
		public System.Windows.Forms.PictureBox coverArt;
		private System.Windows.Forms.Label footerVersion;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label dlProgressLabel;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.LinkLabel footerLink;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.TextBox dlProgressInfoTextbox;
	}
}


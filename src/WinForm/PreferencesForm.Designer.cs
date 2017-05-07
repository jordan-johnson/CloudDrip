namespace CloudDrip.WinForm {
	partial class PreferencesForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
			this.saveButton = new System.Windows.Forms.Button();
			this.startupGroupBox = new System.Windows.Forms.GroupBox();
			this.autoPasteCheckbox = new System.Windows.Forms.CheckBox();
			this.rememberPathCheckbox = new System.Windows.Forms.CheckBox();
			this.otherGroupBox = new System.Windows.Forms.GroupBox();
			this.showDownloadInfoCheckbox = new System.Windows.Forms.CheckBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.proxyGroupBox = new System.Windows.Forms.GroupBox();
			this.proxyCheckbox = new System.Windows.Forms.CheckBox();
			this.proxyPortField = new System.Windows.Forms.TextBox();
			this.proxyPortLabel = new System.Windows.Forms.Label();
			this.proxyAddressLabel = new System.Windows.Forms.Label();
			this.proxyAddressField = new System.Windows.Forms.TextBox();
			this.startupGroupBox.SuspendLayout();
			this.otherGroupBox.SuspendLayout();
			this.proxyGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(12, 206);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(108, 23);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Save && Close";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// startupGroupBox
			// 
			this.startupGroupBox.Controls.Add(this.autoPasteCheckbox);
			this.startupGroupBox.Controls.Add(this.rememberPathCheckbox);
			this.startupGroupBox.Location = new System.Drawing.Point(12, 12);
			this.startupGroupBox.Name = "startupGroupBox";
			this.startupGroupBox.Size = new System.Drawing.Size(381, 66);
			this.startupGroupBox.TabIndex = 6;
			this.startupGroupBox.TabStop = false;
			this.startupGroupBox.Text = "Startup";
			// 
			// autoPasteCheckbox
			// 
			this.autoPasteCheckbox.AutoSize = true;
			this.autoPasteCheckbox.Location = new System.Drawing.Point(6, 43);
			this.autoPasteCheckbox.Name = "autoPasteCheckbox";
			this.autoPasteCheckbox.Size = new System.Drawing.Size(146, 17);
			this.autoPasteCheckbox.TabIndex = 3;
			this.autoPasteCheckbox.Text = "Auto-paste from clipboard";
			this.autoPasteCheckbox.UseVisualStyleBackColor = true;
			// 
			// rememberPathCheckbox
			// 
			this.rememberPathCheckbox.AutoSize = true;
			this.rememberPathCheckbox.Checked = true;
			this.rememberPathCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.rememberPathCheckbox.Location = new System.Drawing.Point(6, 19);
			this.rememberPathCheckbox.Name = "rememberPathCheckbox";
			this.rememberPathCheckbox.Size = new System.Drawing.Size(164, 17);
			this.rememberPathCheckbox.TabIndex = 1;
			this.rememberPathCheckbox.Text = "Remember path to save drips";
			this.rememberPathCheckbox.UseVisualStyleBackColor = true;
			// 
			// otherGroupBox
			// 
			this.otherGroupBox.Controls.Add(this.showDownloadInfoCheckbox);
			this.otherGroupBox.Location = new System.Drawing.Point(12, 154);
			this.otherGroupBox.Name = "otherGroupBox";
			this.otherGroupBox.Size = new System.Drawing.Size(381, 46);
			this.otherGroupBox.TabIndex = 7;
			this.otherGroupBox.TabStop = false;
			this.otherGroupBox.Text = "Other";
			// 
			// showDownloadInfoCheckbox
			// 
			this.showDownloadInfoCheckbox.AutoSize = true;
			this.showDownloadInfoCheckbox.Location = new System.Drawing.Point(6, 19);
			this.showDownloadInfoCheckbox.Name = "showDownloadInfoCheckbox";
			this.showDownloadInfoCheckbox.Size = new System.Drawing.Size(122, 17);
			this.showDownloadInfoCheckbox.TabIndex = 5;
			this.showDownloadInfoCheckbox.Text = "Show download info";
			this.showDownloadInfoCheckbox.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(318, 206);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// proxyGroupBox
			// 
			this.proxyGroupBox.Controls.Add(this.proxyCheckbox);
			this.proxyGroupBox.Controls.Add(this.proxyPortField);
			this.proxyGroupBox.Controls.Add(this.proxyPortLabel);
			this.proxyGroupBox.Controls.Add(this.proxyAddressLabel);
			this.proxyGroupBox.Controls.Add(this.proxyAddressField);
			this.proxyGroupBox.Location = new System.Drawing.Point(12, 84);
			this.proxyGroupBox.Name = "proxyGroupBox";
			this.proxyGroupBox.Size = new System.Drawing.Size(381, 64);
			this.proxyGroupBox.TabIndex = 9;
			this.proxyGroupBox.TabStop = false;
			this.proxyGroupBox.Text = "Proxy";
			// 
			// proxyCheckbox
			// 
			this.proxyCheckbox.AutoSize = true;
			this.proxyCheckbox.Location = new System.Drawing.Point(316, 41);
			this.proxyCheckbox.Name = "proxyCheckbox";
			this.proxyCheckbox.Size = new System.Drawing.Size(59, 17);
			this.proxyCheckbox.TabIndex = 4;
			this.proxyCheckbox.Text = "Enable";
			this.proxyCheckbox.UseVisualStyleBackColor = true;
			this.proxyCheckbox.CheckedChanged += new System.EventHandler(this.proxyCheckbox_CheckedChanged);
			// 
			// proxyPortField
			// 
			this.proxyPortField.Enabled = false;
			this.proxyPortField.Location = new System.Drawing.Point(166, 33);
			this.proxyPortField.MaxLength = 4;
			this.proxyPortField.Name = "proxyPortField";
			this.proxyPortField.Size = new System.Drawing.Size(44, 20);
			this.proxyPortField.TabIndex = 3;
			// 
			// proxyPortLabel
			// 
			this.proxyPortLabel.AutoSize = true;
			this.proxyPortLabel.Location = new System.Drawing.Point(163, 17);
			this.proxyPortLabel.Name = "proxyPortLabel";
			this.proxyPortLabel.Size = new System.Drawing.Size(26, 13);
			this.proxyPortLabel.TabIndex = 2;
			this.proxyPortLabel.Text = "Port";
			// 
			// proxyAddressLabel
			// 
			this.proxyAddressLabel.AutoSize = true;
			this.proxyAddressLabel.Location = new System.Drawing.Point(6, 17);
			this.proxyAddressLabel.Name = "proxyAddressLabel";
			this.proxyAddressLabel.Size = new System.Drawing.Size(45, 13);
			this.proxyAddressLabel.TabIndex = 1;
			this.proxyAddressLabel.Text = "Address";
			// 
			// proxyAddressField
			// 
			this.proxyAddressField.Enabled = false;
			this.proxyAddressField.Location = new System.Drawing.Point(8, 33);
			this.proxyAddressField.MaxLength = 255;
			this.proxyAddressField.Name = "proxyAddressField";
			this.proxyAddressField.Size = new System.Drawing.Size(144, 20);
			this.proxyAddressField.TabIndex = 0;
			// 
			// PreferencesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 236);
			this.Controls.Add(this.proxyGroupBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.otherGroupBox);
			this.Controls.Add(this.startupGroupBox);
			this.Controls.Add(this.saveButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PreferencesForm";
			this.Text = "CloudDrip Preferences";
			this.startupGroupBox.ResumeLayout(false);
			this.startupGroupBox.PerformLayout();
			this.otherGroupBox.ResumeLayout(false);
			this.otherGroupBox.PerformLayout();
			this.proxyGroupBox.ResumeLayout(false);
			this.proxyGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.GroupBox startupGroupBox;
		private System.Windows.Forms.CheckBox autoPasteCheckbox;
		private System.Windows.Forms.CheckBox rememberPathCheckbox;
		private System.Windows.Forms.GroupBox otherGroupBox;
		private System.Windows.Forms.CheckBox showDownloadInfoCheckbox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox proxyGroupBox;
		private System.Windows.Forms.TextBox proxyPortField;
		private System.Windows.Forms.Label proxyPortLabel;
		private System.Windows.Forms.Label proxyAddressLabel;
		private System.Windows.Forms.TextBox proxyAddressField;
		private System.Windows.Forms.CheckBox proxyCheckbox;
	}
}
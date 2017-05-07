namespace CloudDrip.WinForm {
	partial class ImportForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
			this.csvInputLabel = new System.Windows.Forms.Label();
			this.csvLocation = new System.Windows.Forms.TextBox();
			this.csvBrowseButton = new System.Windows.Forms.Button();
			this.importBeginDownloadButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// csvInputLabel
			// 
			this.csvInputLabel.AutoSize = true;
			this.csvInputLabel.Location = new System.Drawing.Point(9, 9);
			this.csvInputLabel.Name = "csvInputLabel";
			this.csvInputLabel.Size = new System.Drawing.Size(99, 13);
			this.csvInputLabel.TabIndex = 0;
			this.csvInputLabel.Text = "Browse for a CSV...";
			// 
			// csvLocation
			// 
			this.csvLocation.Location = new System.Drawing.Point(12, 25);
			this.csvLocation.Name = "csvLocation";
			this.csvLocation.Size = new System.Drawing.Size(234, 20);
			this.csvLocation.TabIndex = 1;
			// 
			// csvBrowseButton
			// 
			this.csvBrowseButton.Location = new System.Drawing.Point(252, 23);
			this.csvBrowseButton.Name = "csvBrowseButton";
			this.csvBrowseButton.Size = new System.Drawing.Size(41, 23);
			this.csvBrowseButton.TabIndex = 3;
			this.csvBrowseButton.Text = "...";
			this.csvBrowseButton.UseVisualStyleBackColor = true;
			this.csvBrowseButton.Click += new System.EventHandler(this.csvBrowseButton_Click);
			// 
			// importBeginDownloadButton
			// 
			this.importBeginDownloadButton.Enabled = false;
			this.importBeginDownloadButton.Location = new System.Drawing.Point(12, 61);
			this.importBeginDownloadButton.Name = "importBeginDownloadButton";
			this.importBeginDownloadButton.Size = new System.Drawing.Size(107, 23);
			this.importBeginDownloadButton.TabIndex = 4;
			this.importBeginDownloadButton.Text = "Begin Download...";
			this.importBeginDownloadButton.UseVisualStyleBackColor = true;
			this.importBeginDownloadButton.Click += new System.EventHandler(this.importBeginDownloadButton_Click);
			// 
			// ImportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 96);
			this.Controls.Add(this.importBeginDownloadButton);
			this.Controls.Add(this.csvBrowseButton);
			this.Controls.Add(this.csvLocation);
			this.Controls.Add(this.csvInputLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ImportForm";
			this.Text = "CloudDrip Import CSV";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label csvInputLabel;
		private System.Windows.Forms.TextBox csvLocation;
		private System.Windows.Forms.Button csvBrowseButton;
		private System.Windows.Forms.Button importBeginDownloadButton;
	}
}
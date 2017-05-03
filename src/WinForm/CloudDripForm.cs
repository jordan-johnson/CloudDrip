using System;
using System.Windows.Forms;
using CloudDrip.Core;
using System.Diagnostics;

namespace CloudDrip.WinForm {
	public partial class CloudDripForm : Form {
		/// <summary>
		/// The glue to hold everything together :)
		/// </summary>
		private Initializer init;

		/// <summary>
		/// Used in accessing form controls
		/// </summary>
		public static CloudDripForm _form;

		/// <summary>
		/// Initialize form, set window position,
		/// and instantiate core
		/// </summary>
		public CloudDripForm() {
			// required for designer
			InitializeComponent();

			_form = this;

			StartPosition = FormStartPosition.CenterScreen;

			init = new Initializer();
		}

		/// <summary>
		/// Set progress label and progress bar value
		/// </summary>
		/// <param name="message">Label</param>
		/// <param name="progress">Value</param>
		public static void SetProgress(string message, int progress) {
			_form.dlProgressLabel.Text = message;

			_form.progressBar.Value = progress;
		}

		/// <summary>
		/// When downloading track, update the artwork
		/// thumbnail
		/// </summary>
		/// <param name="url"></param>
		public static void ChangeArtwork(string url) {
			_form.coverArt.Load(url);
		}

		/// <summary>
		/// If something goes wrong, update progress
		/// </summary>
		/// <param name="message"></param>
		public static void InterruptProgress(string message) {
			SetProgress("Service interrupted... " + message, 0);
		}

		/// <summary>
		/// Open dialog to browse for save directory
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void browseDirectoryClicked(object sender, EventArgs e) {
			FolderBrowserDialog dialog = new FolderBrowserDialog();

			if(dialog.ShowDialog() == DialogResult.OK) {
				pathField.Text = dialog.SelectedPath;
			}
		}

		/// <summary>
		/// Begin download process
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void downloadButtonClicked(object sender, EventArgs e) {
			init.Begin(pathField.Text, urlField.Text);
		}

		/// <summary>
		/// Paste from clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pasteButtonClicked(object sender, EventArgs e) {
			urlField.Text = Clipboard.GetText();
		}

		/// <summary>
		/// Opens link to my github profile
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void footerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			string url = footerLink.Text;

			Process.Start(url);
		}
	}
}

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using CloudDrip.Core;
using CloudDrip.Core.Writer;

namespace CloudDrip.WinForm {
	public partial class CloudDripForm : Form {
		/// <summary>
		/// The glue to hold everything together :)
		/// </summary>
		private Initializer init = new Initializer();

		/// <summary>
		/// Used in accessing form controls
		/// </summary>
		public static CloudDripForm _form;

		/// <summary>
		/// Child forms
		/// </summary>
		private Dictionary<string, Form> additionalForms;

		/// <summary>
		/// Initialize form, set window position,
		/// and instantiate core
		/// </summary>
		public CloudDripForm() {
			// required for designer
			InitializeComponent();

			// Set static instance
			_form = this;

			// setup child forms
			loadForms();

			// adjust form based on preferences
			checkPreferences();

			StartPosition = FormStartPosition.CenterScreen;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;

			// Both Console and Download Info to be used by Console.WriteLine
			Console.SetOut(new MultiWriter(dlProgressInfoTextbox));
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
			Console.WriteLine("Service interrupted... " + message);
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

				/**
				 * If save preference, update the 
				 * json file
				 */
				PreferenceHandler ph = init.Preferences;
				
				if(ph.Data.SavePath) {
					ph.Data.SavedPath = pathField.Text;

					ph.Update();
				}
			}
		}

		/// <summary>
		/// Begin download process
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void downloadButtonClicked(object sender, EventArgs e) {
			// Clears download info textbox but not console
			Console.Out.Flush();

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

		/// <summary>
		/// Create child forms
		/// </summary>
		private void loadForms() {
			additionalForms = new Dictionary<string, Form>();

			additionalForms.Add("import", new ImportForm(this));
			additionalForms.Add("preferences", new PreferencesForm(this, init.Preferences));
		}

		/// <summary>
		/// Check preferences to make adjustments to form
		/// </summary>
		private void checkPreferences() {
			PreferenceHandler ph = init.Preferences;
			
			if(ph.Data.SavePath) {
				pathField.Text = ph.Data.SavedPath;
			}

			if(ph.Data.AutoPaste) {
				urlField.Text = Clipboard.GetText();
			}

			/**
			 * Remember if download info textbox
			 * should be displayed
			 */
			dlProgressInfoTextbox.Visible = ph.Data.ShowDownloadLog;

			/**
			 * If both textbox visibility and preference
			 * are set to false (hide), reduce window height
			 * by textbox size
			 */
			if(!dlProgressInfoTextbox.Visible && !ph.Data.ShowDownloadLog) {
				Height -= 96;
			}
		}

		/// <summary>
		/// Toggle display of download info box
		/// </summary>
		/// <param name="value">true/false</param>
		public void DisplayDownloadInfo(bool value) {
			if(value && !dlProgressInfoTextbox.Visible) {
				Height += 96;

				dlProgressInfoTextbox.Show();
			} else if(!value && dlProgressInfoTextbox.Visible) {
				Height -= 96;

				dlProgressInfoTextbox.Hide();
			}
		}

		/// <summary>
		/// Import form opener
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importToolStripMenuItem_Click(object sender, EventArgs e) {
			Form importForm = additionalForms["import"];

			importForm.ShowDialog(this);
		}

		/// <summary>
		/// Preference form opener
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
			Form prefForm = additionalForms["preferences"];

			prefForm.ShowDialog(this);
		}

		/// <summary>
		/// Exit application via menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// About message via menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) {
			MessageBox.Show("Download tracks from SoundCloud. This is purely for educational purposes so I can learn Windows Forms. " +
					"I do not condone downloading content unless it's available to download on the artist's SoundCloud profile. Support your artists!", 
					"About CloudDrip");
		}
	}
}

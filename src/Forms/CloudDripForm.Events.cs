using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows.Forms;
using CloudDrip.Core;

namespace CloudDrip.Forms {
	partial class CloudDripForm {
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
				PreferenceHandler ph = _init.Preferences;
				
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

			_init.Start(pathField.Text, urlField.Text);
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
		/// Import form opener
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importToolStripMenuItem_Click(object sender, EventArgs e) {
			_helper.SafeToggleChild("ImportForm");
		}

		/// <summary>
		/// Preference form opener
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
			_helper.SafeToggleChild("PreferencesForm");
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

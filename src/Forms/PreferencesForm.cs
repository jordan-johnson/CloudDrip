using System;
using System.Windows.Forms;
using CloudDrip.Core;
using CloudDrip.Helpers;

namespace CloudDrip.Forms {
	/// <summary>
	/// PreferencesForm gives the user options such as proxy, remember save path, auto-paste on startup, etc.
	/// </summary>
	public partial class PreferencesForm : Form {
		private PreferenceHandler _ph;

		private FormHelper _helper;

		/// <summary>
		/// Used in remembering previous settings (it's saved in preferences.json)
		/// </summary>
		private void checkPreferences() {
			autoPasteCheckbox.Checked = _ph.Data.AutoPaste;
			rememberPathCheckbox.Checked = _ph.Data.SavePath;
			showDownloadInfoCheckbox.Checked = _ph.Data.ShowDownloadLog;
			proxyCheckbox.Checked = _ph.Data.Proxy;
			proxyAddressField.Text = _ph.Data.ProxyIP;
			proxyPortField.Text = _ph.Data.ProxyPort.ToString();
		}

		/// <summary>
		/// Save changes to preferences.json
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveButton_Click(object sender, EventArgs e) {
			_ph.Data.AutoPaste = autoPasteCheckbox.Checked;
			_ph.Data.SavePath = rememberPathCheckbox.Checked;
			_ph.Data.ShowDownloadLog = showDownloadInfoCheckbox.Checked;
			_ph.Data.Proxy = proxyCheckbox.Checked;
			_ph.Data.ProxyIP = proxyAddressField.Text;
			_ph.Data.ProxyPort = int.Parse(proxyPortField.Text);

			/**
			 * This little line helps toggle
			 * the download info box by referencing
			 * the parent form (CloudDripForm)
			 */
			_helper.Parent.DisplayDownloadInfo(_ph.Data.ShowDownloadLog);

			_ph.Update();

			Close();
		}

		/// <summary>
		/// Cancel button for closing form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cancelButton_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// Toggles address and port fields if proxy is enabled/disabled
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void proxyCheckbox_CheckedChanged(object sender, EventArgs e) {
			proxyAddressField.Enabled = proxyCheckbox.Checked;
			proxyPortField.Enabled = proxyCheckbox.Checked;
		}

		/// <summary>
		/// GUI for preferences
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="handler"></param>
		public PreferencesForm(CloudDripForm parent, PreferenceHandler handler) {
			InitializeComponent();

			_helper = new FormHelper(this);
			_helper.Defaults();

			_helper.Parent = parent;

			_ph = handler;

			checkPreferences();
		}
	}
}

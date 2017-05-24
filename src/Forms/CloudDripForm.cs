using System;
using System.Windows.Forms;
using CloudDrip.Core;
using CloudDrip.Core.Writer;
using CloudDrip.Helpers;

namespace CloudDrip.Forms {
	public partial class CloudDripForm : Form {
		/// <summary>
		/// The glue to hold everything together :)
		/// </summary>
		private Initializer _init = new Initializer();

		/// <summary>
		/// Used in accessing form controls
		/// </summary>
		private static CloudDripForm _form;

		/// <summary>
		/// Form helper
		/// </summary>
		private FormHelper _helper;

		/// <summary>
		/// Create child forms
		/// </summary>
		private void loadForms() {
			_helper.AddChild(new ImportForm(this));
			_helper.AddChild(new PreferencesForm(this, _init.Preferences));
		}

		/// <summary>
		/// Check preferences to make adjustments to form
		/// </summary>
		private void checkPreferences() {
			PreferenceHandler ph = _init.Preferences;
			
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
		/// Initialize form, set window position,
		/// and instantiate core
		/// </summary>
		public CloudDripForm() {
			// required for designer
			InitializeComponent();

			// Set static instance
			_form = this;
			
			/**
			 * Instantiate form helper and set
			 * form style defaults
			 */
			_helper = new FormHelper(_form);
			_helper.Defaults();

			// setup child forms
			loadForms();

			// adjust form based on preferences
			checkPreferences();

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
	}
}

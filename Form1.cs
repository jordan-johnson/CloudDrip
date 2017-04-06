using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using CloudDrip;

namespace CloudDrip {
	public partial class Form1 :Form {
		public CDCore core {get;set;}

		/// <summary>
		/// Used in accessing form controls
		/// </summary>
		public static Form1 _form;

		/// <summary>
		/// Initialize form, set window position,
		/// and instantiate core
		/// </summary>
		public Form1() {
			InitializeComponent();

			_form = this;

			StartPosition = FormStartPosition.CenterScreen;

			core = new CDCore();
		}

		/// <summary>
		/// Browse for directory to save file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e) {
			FolderBrowserDialog dialog = new FolderBrowserDialog();

			if(dialog.ShowDialog() == DialogResult.OK)
				textBox1.Text = dialog.SelectedPath;
		}

		/// <summary>
		/// Download button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e) {
			StartDownload();
		}

		/// <summary>
		/// Paste from clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e) {
			textBox3.Text = Clipboard.GetText();
		}

		/// <summary>
		/// Start download by running checks, requesting track
		/// metadata, and then download file to directory
		/// </summary>
		private void StartDownload() {
			if(core.Initialize(textBox1.Text, textBox3.Text)) {
				CDWeb web = new CDWeb(core);
				web.OpenRequest(core.url);

				CDDeserialize deserialize = new CDDeserialize(web.received);
				SoundCloudTrack track = deserialize.track;

				core.ManageMetadata(track);

				web.OpenDownload(deserialize.track, core.clientId, core.path);

				web.DownloadListener(web);

				web.CloseRequest();
			}
		}
	}
}

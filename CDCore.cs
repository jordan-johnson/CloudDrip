using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudDrip {
	public class CDCore {
		public string path {get;set;}
		public string url {get;set;}
		public string clientId = "bed20744714e9c5962c351efe15840ff";

		/// <summary>
		/// Initialize download by setting properties and
		/// updating the url.
		/// </summary>
		/// <param name="path">Directory</param>
		/// <param name="url">SoundCloud URL</param>
		/// <returns>True if everything is working as intended</returns>
		public bool Initialize(string path, string url) {
			AddProgress("Initializing", 0);
			AddProgress("Establishing connection and getting track metadata", 5, 1);

			SetFields(path, url);

			if(RunChecks()) {
				Redirect();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Set properties
		/// </summary>
		/// <param name="path">Directory</param>
		/// <param name="url">SoundCloud URL</param>
		public void SetFields(string path, string url) {
			this.path = path;
			this.url = url;
		}

		/// <summary>
		/// Display progress of download
		/// </summary>
		/// <param name="message"></param>
		/// <param name="percent"></param>
		/// <param name="tab">Number of times to indent message</param>
		public void AddProgress(string message, int percent, int tab = 0) {
			string tabs = "";

			for(var i = 0; i < tab; i++)
				tabs += "\t";

			Form1._form.textBox2.AppendText(tabs + message + "... " + percent + "%");
			Form1._form.textBox2.AppendText(Environment.NewLine);
		}

		/// <summary>
		/// Check to make sure program doesn't get weird
		/// </summary>
		/// <returns>True if everything is fine</returns>
		public bool RunChecks() {
			if(path == String.Empty || url == String.Empty) {
				AddProgress("Path or URL not specified. Stopped", 100);

				return false;
			}

			return true;
		}

		/// <summary>
		/// User provides standard SoundCloud URL and this function
		/// redirects the program to grab track metadata from json file
		/// </summary>
		public void Redirect() {
			url = "https://api.soundcloud.com/resolve.json?url=" + url + "&client_id=" + clientId;
		}

		/// <summary>
		/// Change the artwork and display the details of the
		/// track
		/// </summary>
		/// <param name="track"></param>
		public void ManageMetadata(SoundCloudTrack track) {
			ChangeArtwork(track.artwork_url);

			WriteMetaData(track);
		}

		/// <summary>
		/// Displays the metadata that will be grabbed and used
		/// in downloading the file.
		/// </summary>
		/// <param name="track">SoundCloudTrack object for metadata</param>
		private void WriteMetaData(SoundCloudTrack track) {
			AddProgress("Track metadata collected", 30, 1);
			AddProgress("Id: " + track.id, 100, 2);
			AddProgress("Title: " + track.title, 100, 2);
			AddProgress("Artwork: " + track.artwork_url, 100, 2);
		}

		/// <summary>
		/// Change the form control "pictureBox2" to
		/// the SoundCloud artwork found in the metadata
		/// </summary>
		/// <param name="url">Link to artwork</param>
		private void ChangeArtwork(string url) {
			// shoutout to the devs who allowed us to load pictures from the web
			Form1._form.pictureBox2.Load(url);
		}
	}
}

using System;
using CloudDrip.WinForm;
using CloudDrip.Http;
using CloudDrip.SoundCloud;

namespace CloudDrip.Core {
	/// <summary>
	/// The glue to everything...
	/// </summary>
	public class Initializer {
		/// <summary>
		/// Handles web requests and pushes
		/// data to data collection
		/// </summary>
		private WebHandler web;

		/// <summary>
		/// Used for writing track metadata
		/// </summary>
		private MetadataHandler meta;

		/// <summary>
		/// Current track being downloaded
		/// </summary>
		private SoundCloudTrack track;

		/// <summary>
		/// Constructor
		/// </summary>
		public Initializer() {
			web = new WebHandler();
			meta = new MetadataHandler();
		}

		/// <summary>
		/// Save path and url then begin download
		/// </summary>
		/// <param name="path">Directory to save track</param>
		/// <param name="url">SoundCloud URL to track</param>
		public void Begin(string path, string url) {
			if(path == String.Empty || url == String.Empty) {
				CloudDripForm.InterruptProgress("path or URL not provided");

				return;
			}

			SetPath(path);

			// used in getting track metadata
			UpdateURL(url);

			Download();
		}

		/// <summary>
		/// Set the save directory
		/// </summary>
		/// <param name="path">Directory</param>
		private void SetPath(string path) {
			Settings.path = path;
		}

		/// <summary>
		/// Converts the SoundCloud URL to retrieve json metadata
		/// </summary>
		/// <param name="url">SoundCloud URL to track</param>
		private void UpdateURL(string url) {
			Settings.url = "https://api.soundcloud.com/resolve.json?url=" + url + "&client_id=" + Settings.clientId;
		}

		/// <summary>
		/// Download track
		/// </summary>
		private void Download() {
			web.OpenRequest(Settings.url);

			Deserializer deserializer = new Deserializer(web.received);
			track = deserializer.track;

			CloudDripForm.ChangeArtwork(track.artwork_url);

			web.OpenDownload(track, Settings.clientId, Settings.path);

			// ApplyMetadata callback once download is complete
			web.DownloadListener(ApplyMetadata);

			web.CloseRequest();
		}

		/// <summary>
		/// Begin writing the track metadata to mp3 file
		/// </summary>
		public void ApplyMetadata() {
			meta.Apply(track, Settings.path);
		}
	}
}

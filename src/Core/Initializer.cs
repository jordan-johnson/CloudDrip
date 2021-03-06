﻿using System;
using System.IO;
using CloudDrip.Forms;
using CloudDrip.Http;
using CloudDrip.Models;

namespace CloudDrip.Core {
	/// <summary>
	/// The glue to everything...
	/// </summary>
	public class Initializer {
		/// <summary>
		/// Handles web requests and pushes
		/// data to data collection
		/// </summary>
		private WebHandler web = new WebHandler();

		/// <summary>
		/// Used for writing track metadata
		/// </summary>
		private MetadataHandler meta = new MetadataHandler();

		/// <summary>
		/// Current track being downloaded
		/// </summary>
		private SoundCloudTrack track;

		/// <summary>
		/// Serialization
		/// </summary>
		private Serialization serialization = new Serialization();

		/// <summary>
		/// Download track
		/// </summary>
		private void Download() {
			// checks if proxy is to be used
			web.SetupProxy(Preferences.Data);

			web.OpenRequest(DownloadVars.URL);

			// convert received message into SoundCloudTrack 
			track = serialization.Deserialize<SoundCloudTrack>(web.Received);

			// changes the thumbnail on main form
			CloudDripForm.ChangeArtwork(track.artwork_url);

			// url, save path, callback when download completes
			web.OpenAsyncDownload(track.stream_url, getMP3Path(), ApplyMetadata);

			web.CloseRequest();
		}

		/// <summary>
		/// Get the full path to the mp3
		/// </summary>
		/// <returns>full path to mp3</returns>
		private string getMP3Path() {
			return DownloadVars.Path + "/" + track.title + ".mp3";
		}

		/// <summary>
		/// Begin writing the track metadata to mp3 file
		/// </summary>
		private void ApplyMetadata() {
			string artCoverUrl = meta.GetArtCover(track);

			track.artwork = web.DownloadDataAsBytes(artCoverUrl);

			meta.Apply(track, DownloadVars.Path);
		}

		/// <summary>
		/// Manage preferences
		/// </summary>
		public PreferenceHandler Preferences = new PreferenceHandler();

		/// <summary>
		/// Run some basic checks and set path, url, then download
		/// </summary>
		/// <param name="path"></param>
		/// <param name="url"></param>
		public void Start(string path, string url) {
			if(path == String.Empty || url == String.Empty) {
				Console.WriteLine("Path or URL not provided. Stopped.");

				return;
			}

			if(!Directory.Exists(path)) {
				Console.WriteLine("Directory does not exist. Stopped.");

				return;
			}

			DownloadVars.Path = path;
			DownloadVars.URL = url;

			Download();
		}
	}
}

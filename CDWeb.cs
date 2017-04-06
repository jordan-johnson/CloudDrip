using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace CloudDrip {
	/// <summary>
	/// CDWeb handles web requests to get SoundCloud track metadata
	/// (such as track id and stream_url) in order to download
	/// songs from SoundCloud
	/// </summary>
	public class CDWeb {
		public CDCore core {get;set;}
		public string received {get;set;}
		public WebResponse response {get;set;}
		public StreamReader reader {get;set;}
		public WebClient client {get;set;}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="core">Referenced for displaying progress</param>
		public CDWeb(CDCore core) {
			this.core = core;
		}

		/// <summary>
		/// Open HTTPWebRequest of specified url and read contents of the page.
		/// </summary>
		/// <param name="url">URL to be read</param>
		public void OpenRequest(string url) {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			request.Credentials = CredentialCache.DefaultCredentials;

			response = request.GetResponse();
			
			Stream dataStream = response.GetResponseStream();
			reader = new StreamReader(dataStream);

			received = reader.ReadToEnd();
		}

		/// <summary>
		/// Close the reader and our request to the server
		/// </summary>
		public void CloseRequest() {
			reader.Close();
			response.Close();
		}

		/// <summary>
		/// Download track through WebClient
		/// </summary>
		/// <param name="track">SoundCloud track object (needs track id and stream_url)</param>
		/// <param name="clientId">Client Id for SoundCloud (can be found in CDCore)</param>
		/// <param name="path">Directory to save mp3</param>
		public void OpenDownload(SoundCloudTrack track, string clientId, string path) {
			client = new WebClient();
			
			path = path + "/" + track.id + ".mp3";

			core.AddProgress("Retrieving file", 70, 1);

			client.DownloadFileAsync(new Uri(track.stream_url + "?client_id=" + clientId), path);
		}

		/// <summary>
		/// Display download progress
		/// </summary>
		/// <param name="web"></param>
		public void DownloadListener(CDWeb web) {
			int progress = 0;

			web.client.DownloadProgressChanged += (s, e) => {
				if(progress != e.ProgressPercentage) {
					core.AddProgress("Downloading", e.ProgressPercentage, 2);
					progress = e.ProgressPercentage;
				}
			};

			web.client.DownloadFileCompleted += (s, e) => {
				core.AddProgress("Download complete. Service stopped", 100, 0);
			};
		}
	}
}

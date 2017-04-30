using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using CloudDrip.WinForm;
using CloudDrip.SoundCloud;
using CloudDrip.Core;

namespace CloudDrip.Http {
	/// <summary>
	/// Need to rewrite this a bit...
	/// </summary>
	public class WebHandler {
		public WebResponse response {get; private set;}
		public StreamReader reader {get; private set;}
		public string received {get; private set;}
		
		private WebClient client;

		/// <summary>
		/// Open request to URL
		/// </summary>
		/// <param name="url"></param>
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
		/// Close any open requests
		/// </summary>
		public void CloseRequest() {
			reader.Close();
			response.Close();
		}

		public void OpenDownload(SoundCloudTrack track, string clientId, string path) {
			client = new WebClient();

			path = path + "/" + track.title + ".mp3";

			// should move this
			GetArtCover(track);

			client.DownloadFileAsync(new Uri(track.stream_url + "?client_id=" + clientId), path);
		}

		/// <summary>
		/// Listen for download progress. On complete, call method provided
		/// </summary>
		/// <param name="when_complete">Callback when download complete</param>
		public void DownloadListener(Action when_complete) {
			int progress = 0;
			
			client.DownloadProgressChanged += (s, e) => {
				if(progress != e.ProgressPercentage) {
					CloudDripForm.SetProgress("Downloading...", e.ProgressPercentage);
					progress = e.ProgressPercentage;
				}
			};

			client.DownloadFileCompleted += (s, e) => {
				when_complete();
			};
		}
		
		private void GetArtCover(SoundCloudTrack track) {
			int index = track.artwork_url.LastIndexOf('-');
			
			string strStart = track.artwork_url.Substring(0, index);

			string final = strStart + "-t500x500.jpg";

			track.artwork = client.DownloadData(new Uri(final));
		}
	}
}

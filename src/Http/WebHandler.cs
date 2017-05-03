using System;
using System.IO;
using System.Net;
using CloudDrip.WinForm;

namespace CloudDrip.Http {
	/// <summary>
	/// Need to rewrite this a bit...
	/// </summary>
	public class WebHandler {
		private WebResponse response;
		private StreamReader reader;
		private WebClient client;

		public string received {get; private set;}

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

		/// <summary>
		/// Download file asynchronously
		/// </summary>
		/// <param name="url">URL</param>
		/// <param name="path"></param>
		/// <param name="callback"></param>
		public void OpenAsyncDownload(string url, string path, Action callback) {
			using(client = new WebClient()) {
				client.DownloadFileAsync(new Uri(url), path);
				DownloadListener(callback);
			}
		}

		/// <summary>
		/// Returns byte array from WebClient's DownloadData method
		/// </summary>
		/// <param name="url">URL To file</param>
		/// <returns></returns>
		public byte[] DownloadDataAsBytes(string url) {
			return client.DownloadData(new Uri(url));
		}

		/// <summary>
		/// Listen for download progress. On complete, call method provided
		/// </summary>
		/// <param name="when_complete">Callback when download complete</param>
		private void DownloadListener(Action when_complete) {
			int progress = 0;
			
			client.DownloadProgressChanged += (s, e) => {
				if(progress != e.ProgressPercentage) {
					CloudDripForm.SetProgress("Downloading...", e.ProgressPercentage);

					progress = e.ProgressPercentage;
				}
			};

			client.DownloadFileCompleted += (s, e) => {
				when_complete();

				/**
				 * may need to update this when i start working on 
				 * downloading multiple files
				 */
				client.Dispose();
			};
		}
	}
}

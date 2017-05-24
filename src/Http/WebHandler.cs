using System;
using System.IO;
using System.Net;
using CloudDrip.Forms;
using CloudDrip.Models;

namespace CloudDrip.Http {
	/// <summary>
	/// Handles any web communication
	/// </summary>
	public class WebHandler {
		/// <summary>
		/// Response from request
		/// </summary>
		private WebResponse _response;

		/// <summary>
		/// Content reader
		/// </summary>
		private StreamReader _reader;

		/// <summary>
		/// WebClient for downloading
		/// </summary>
		private WebClient _client;

		/// <summary>
		/// Check if connection was established
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		private bool checkRequest(HttpWebRequest request) {
			if(request != null) {
				Console.WriteLine("Connection established.");

				return true;
			} else {
				Console.WriteLine("Connection could not be established. Stopping.");

				return false;
			}
		}

		/// <summary>
		/// Use proxy if preference dictates
		/// </summary>
		/// <param name="request"></param>
		private void connectProxy(HttpWebRequest request) {
			if(UseProxy) {
				Console.WriteLine("Using proxy for request, please wait... " + ProxyAddress + ":" + ProxyPort);

				request.Proxy = new WebProxy(ProxyAddress, ProxyPort);
			}
		}

		/// <summary>
		/// Use proxy if preference dictates
		/// </summary>
		/// <param name="client"></param>
		private void connectProxy(WebClient client) {
			if(UseProxy) {
				Console.WriteLine("Using proxy for download, please wait... " + ProxyAddress + ":" + ProxyPort);

				client.Proxy = new WebProxy(ProxyAddress, ProxyPort);
			}
		}

		/// <summary>
		/// Listen for download progress. On complete, call method provided
		/// </summary>
		/// <param name="when_complete">Callback when download complete</param>
		private void DownloadListener(Action when_complete) {
			int progress = 0;
			
			_client.DownloadProgressChanged += (s, e) => {
				if(progress != e.ProgressPercentage) {
					CloudDripForm.SetProgress("Downloading...", e.ProgressPercentage);

					progress = e.ProgressPercentage;
				}
			};

			_client.DownloadFileCompleted += (s, e) => {
				Console.WriteLine("Download complete.");

				when_complete();

				/**
				 * may need to update this when i start working on 
				 * downloading multiple files
				 */
				_client.Dispose();
			};
		}

		/// <summary>
		/// Message returned from request
		/// </summary>
		public string Received {get; private set;}

		/// <summary>
		/// Determines if proxy will be  used (relies on preference)
		/// </summary>
		public bool UseProxy {get;set;}

		/// <summary>
		/// Address
		/// </summary>
		public string ProxyAddress {get;set;}

		/// <summary>
		/// Port
		/// </summary>
		public int ProxyPort {get;set;}

		/// <summary>
		/// Open request to URL
		/// </summary>
		/// <param name="url"></param>
		public void OpenRequest(string url) {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			if(!checkRequest(request)) {
				return;
			}

			connectProxy(request);

			request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			request.Credentials = CredentialCache.DefaultCredentials;

			_response = request.GetResponse();

			Stream dataStream = _response.GetResponseStream();
			_reader = new StreamReader(dataStream);

			Received = _reader.ReadToEnd();
		}

		/// <summary>
		/// Close any open requests
		/// </summary>
		public void CloseRequest() {
			if(_reader != null) {
				_reader.Close();
			}

			if(_response != null) {
				_response.Close();
			}
		}

		/// <summary>
		/// Download file asynchronously
		/// </summary>
		/// <param name="url">URL</param>
		/// <param name="path"></param>
		/// <param name="callback"></param>
		public void OpenAsyncDownload(string url, string path, Action callback) {
			using(_client = new WebClient()) {
				connectProxy(_client);

				Console.WriteLine("Downloading...");

				_client.DownloadFileAsync(new Uri(url), path);
				DownloadListener(callback);
			}
		}

		/// <summary>
		/// Check if proxy is requested via preferences then assigns address and port
		/// </summary>
		/// <param name="preferences">User preferences</param>
		public void SetupProxy(Preferences preferences) {
			UseProxy = preferences.Proxy;

			if(UseProxy) {
				ProxyAddress = preferences.ProxyIP;
				ProxyPort = preferences.ProxyPort;
			}
		}

		/// <summary>
		/// Returns byte array from WebClient's DownloadData method
		/// </summary>
		/// <param name="url">URL To file</param>
		/// <returns></returns>
		public byte[] DownloadDataAsBytes(string url) {
			return _client.DownloadData(new Uri(url));
		}
	}
}

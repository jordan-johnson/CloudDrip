namespace CloudDrip.Core.Serialize {
	/// <summary>
	/// Extension of SoundCloudTrack
	/// </summary>
	public class User {
		/// <summary>
		/// Used in setting artist tag
		/// </summary>
		public string username {get;set;}
	}

	/// <summary>
	/// SoundCloud track metadata object (for serialization)
	/// </summary>
	public class SoundCloudTrack {
		public string id {get;set;}

		public string title {get;set;}

		public string artwork_url {get;set;}

		public string stream_url {
			get {
				return _full_stream_url;
			}
			set {
				string clientId = DownloadVars.ClientId;

				_full_stream_url = value + "?client_id=" + clientId;
			}
		}

		public string genre {get;set;}

		public User user {get;set;}

		public byte[] artwork {get;set;}

		private string _full_stream_url;
	}
}
using CloudDrip.Core;

namespace CloudDrip.SoundCloud {
	public class User {
		public string username {get;set;}
	}

	public class SoundCloudTrack {
		public string id {get;set;}

		public string title {get;set;}

		public string artwork_url {get;set;}

		public string stream_url {
			get {
				return _full_stream_url;
			}
			set {
				string clientId = Settings.clientId;

				_full_stream_url = value + "?client_id=" + clientId;
			}
		}

		public string genre {get;set;}

		public User user {get;set;}

		public byte[] artwork {get;set;}

		private string _full_stream_url;
	}
}
using CloudDrip.Core;

namespace CloudDrip.Models {
	/// <summary>
	/// SoundCloud track metadata object (for serialization)
	/// </summary>
	public class SoundCloudTrack {
		/// <summary>
		/// Contains the full stream url along with client id
		/// </summary>
		private string _full_stream_url;

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
		/// Track's unique id
		/// </summary>
		public string id {get;set;}

		/// <summary>
		/// Track name
		/// </summary>
		public string title {get;set;}

		/// <summary>
		/// Address to artwork
		/// </summary>
		public string artwork_url {get;set;}

		/// <summary>
		/// Address to track
		/// </summary>
		public string stream_url {
			get {
				return _full_stream_url;
			}
			set {
				string clientId = DownloadVars.ClientId;

				_full_stream_url = value + "?client_id=" + clientId;
			}
		}

		/// <summary>
		/// Track genre
		/// </summary>
		public string genre {get;set;}

		/// <summary>
		/// Uploader's user info
		/// </summary>
		public User user {get;set;}

		/// <summary>
		/// Artwork to be used in MetadataHandler
		/// </summary>
		public byte[] artwork {get;set;}
	}
}
namespace CloudDrip.Core {
	/// <summary>
	/// Basic download variables (path, url, client id)
	/// </summary>
	public class DownloadVars {
		/// <summary>
		/// Full URL to SoundCloud track json doc
		/// </summary>
		private static string _url;

		/// <summary>
		/// Client Id that SoundCloud needs to download
		/// </summary>
		public static string ClientId = "bed20744714e9c5962c351efe15840ff";

		/// <summary>
		/// Path to save directory
		/// </summary>
		public static string Path {get;set;}

		/// <summary>
		/// Full URL to track metadata
		/// </summary>
		public static string URL {
			get {
				return _url;
			}
			set {
				_url = "https://api.soundcloud.com/resolve.json?url=" + value + "&client_id=" + ClientId;
			}
		}
	}
}
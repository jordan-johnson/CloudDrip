namespace CloudDrip.Models {
	public class Preferences {
		public bool SavePath {get;set;}
		public string SavedPath {get;set;}
		public bool AutoPaste {get;set;}
		public bool ShowDownloadLog {get;set;}
		public bool Proxy {get;set; }
		public string ProxyIP {get;set;}
		public int ProxyPort {get;set;}
	}
}

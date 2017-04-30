using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDrip.SoundCloud {
	public class User {
		public string username {get;set;}
	}

	public class SoundCloudTrack {
		public string id {get;set;}
		public string title {get;set;}
		public string artwork_url {get;set;}
		public string stream_url {get;set;}
		public string genre {get;set;}
		public User user {get;set;} 
		public byte[] artwork {get;set;}
	}
}
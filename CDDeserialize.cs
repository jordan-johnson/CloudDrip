using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudDrip;
using System.Web.Script.Serialization;

namespace CloudDrip {
	public class CDDeserialize {
		public SoundCloudTrack track {get;set;}

		public CDDeserialize(string message) {
			track = new JavaScriptSerializer().Deserialize<SoundCloudTrack>(message);
		}
	}
}

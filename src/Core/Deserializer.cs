using System.Web.Script.Serialization;
using CloudDrip.SoundCloud;

namespace CloudDrip.Core {
	public class Deserializer {
		public SoundCloudTrack track {get; private set;}

		public Deserializer(string message) {
			track = new JavaScriptSerializer().Deserialize<SoundCloudTrack>(message);
		}
	}
}

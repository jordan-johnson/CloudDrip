using System.Web.Script.Serialization;
using CloudDrip.SoundCloud;

namespace CloudDrip.Core {
	public class Deserializer<T> {
		public T data {get; private set;}

		public Deserializer(string message) {
			data = new JavaScriptSerializer().Deserialize<T>(message);
		}
	}
}

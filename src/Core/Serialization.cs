using System.Web.Script.Serialization;
using System.IO;

namespace CloudDrip.Core {
	public class Serialization {
		public dynamic data {get; private set;}

		public void Serialize(dynamic obj, string path) {
			data = new JavaScriptSerializer().Serialize(obj);

			File.WriteAllText(path, data);
		}

		public bool FileFound(string path) {
			return File.Exists(path);
		}

		public T Deserialize<T>(string message) {
			return new JavaScriptSerializer().Deserialize<T>(message);
		}

		public T DeserializeFile<T>(string path) {
			return (T)new JavaScriptSerializer().Deserialize(File.ReadAllText(path), typeof(T));
		}
	}
}

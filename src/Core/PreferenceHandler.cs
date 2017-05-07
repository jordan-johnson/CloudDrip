using System;
using CloudDrip.Core.Serialize;

namespace CloudDrip.Core {
	/// <summary>
	/// Handles all preference reading and updating
	/// </summary>
	public class PreferenceHandler {
		/// <summary>
		/// Preference structure
		/// </summary>
		public Preferences Data {get;set;}

		/// <summary>
		/// Serializer... should make this static in the next update
		/// </summary>
		private Serialization _serialization;

		/// <summary>
		/// Default preference file name
		/// </summary>
		private const string _file = "preferences.json";

		/// <summary>
		/// Constructor determines if a preference file needs to be created or read
		/// </summary>
		public PreferenceHandler() {
			_serialization = new Serialization();

			if(!_serialization.FileFound(_file)) {
				writeNew();
			} else {
				getContent();
			}
		}

		/// <summary>
		/// Create default preference json file
		/// </summary>
		private void writeNew() {
			Data = new Preferences();

			Data.AutoPaste = false;
			Data.SavePath = true;
			Data.ShowDownloadLog = false;
			Data.Proxy = false;

			Update();
		}

		/// <summary>
		/// Read preference file
		/// </summary>
		private void getContent() {
			Data = _serialization.DeserializeFile<Preferences>(_file);
		}

		/// <summary>
		/// Save chanegs to preference file
		/// </summary>
		public void Update() {
			_serialization.Serialize(Data, _file);
		}
	}
}

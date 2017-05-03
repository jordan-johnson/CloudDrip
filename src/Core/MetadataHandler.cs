using TagLib;
using CloudDrip.SoundCloud;
using CloudDrip.WinForm;

namespace CloudDrip.Core {
	public class MetadataHandler {
		/// <summary>
		/// MP3 to be modified
		/// </summary>
		private File mp3file;

		/// <summary>
		/// Track metadata
		/// </summary>
		private SoundCloudTrack track;

		/// <summary>
		/// Path to mp3
		/// </summary>
		private string path;

		/// <summary>
		/// Apply metadata
		/// </summary>
		/// <param name="track">Track metadata</param>
		/// <param name="path">Path to mp3</param>
		public void Apply(SoundCloudTrack track, string path) {
			this.track = track;
			this.path = path;

			CloudDripForm.SetProgress("Applying track metadata... please wait", 100);

			mp3file = File.Create(this.path + "/" + track.title + ".mp3");
			
			SetBasic();
			SetPicture();

			Save();
		}

		/// <summary>
		/// Corrects the URL to get the full size cover
		/// </summary>
		/// <param name="track"></param>
		/// <returns>URL to full size artwork cover</returns>
		public string GetArtCover(SoundCloudTrack track) {
			int index = track.artwork_url.LastIndexOf('-');
			
			string strStart = track.artwork_url.Substring(0, index);

			return strStart + "-t500x500.jpg";
		}

		/// <summary>
		/// Set basic tags (title, artist, genre)
		/// </summary>
		private void SetBasic() {
			mp3file.Tag.Title = track.title;
			mp3file.Tag.AlbumArtists = new string[]{ track.user.username };
			mp3file.Tag.Genres = new string[] { track.genre };
		}

		/// <summary>
		/// Set cover art
		/// </summary>
		private void SetPicture() {
			if(track.artwork != null) {
				IPicture[] pics = new IPicture[1];

				pics[0] = new Picture(track.artwork);

				mp3file.Tag.Pictures = pics;
			}
		}

		/// <summary>
		/// Save changes to mp3
		/// </summary>
		private void Save() {
			CloudDripForm.SetProgress("Ready.", 0);
			mp3file.Save();
		}
	}
}

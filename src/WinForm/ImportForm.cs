using System;
using System.IO;
using System.Windows.Forms;

namespace CloudDrip.WinForm {
	/// <summary>
	/// Import form is not finished. Async downloads became too much of a headache for 1.1
	/// </summary>
	public partial class ImportForm :Form {
		private CloudDripForm _parent;

		public ImportForm(CloudDripForm parent) {
			InitializeComponent();

			StartPosition = FormStartPosition.CenterScreen;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;

			_parent = parent;
		}

		private void importBeginDownloadButton_Click(object sender, EventArgs e) {
			string[] urls = File.ReadAllText(csvLocation.Text).Split(',');

			Close();
		}

		private void csvBrowseButton_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();

			if(dialog.ShowDialog() == DialogResult.OK) {
				csvLocation.Text = dialog.FileName;
			}
		}
	}
}

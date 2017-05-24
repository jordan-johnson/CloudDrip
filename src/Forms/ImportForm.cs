using System;
using System.IO;
using System.Windows.Forms;
using CloudDrip.Helpers;

namespace CloudDrip.Forms {
	/// <summary>
	/// Import form is not finished. Async downloads became too much of a headache for 1.1
	/// </summary>
	public partial class ImportForm : Form {
		private FormHelper _helper;

		public ImportForm(CloudDripForm parent) {
			InitializeComponent();

			_helper = new FormHelper(this);

			_helper.Defaults();
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

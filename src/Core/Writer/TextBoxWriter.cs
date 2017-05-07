using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CloudDrip.Core.Writer {
	/// <summary>
	/// TextBoxWriter allows me to use Console.WriteLine to display progress in Download Info textbox
	/// </summary>
	public class TextBoxWriter : TextWriter {
		private TextBox _textbox;

		public TextBoxWriter(TextBox textbox) {
			_textbox = textbox;
		}

		public override void Write(char value) {
			/**
			 * For some reason, this function gets called instead
			 * of the overloaded string function. I needed  
			 * AppendText's scroll functionality so I wrote it
			 * manually. Otherwise, AppendText writes a character
			 * per line. Weird -- need to look into this eventually.
			 */
			_textbox.Text += value + "\n";
			_textbox.SelectionStart = _textbox.Text.Length;
			_textbox.ScrollToCaret();
		}

		public override void Write(string value) {
			_textbox.AppendText(value + "\n");
		}

		public override void Flush() {
			_textbox.Text = String.Empty;
		}

		public override Encoding Encoding {
			get {
				return Encoding.ASCII;
			}
		}
	}
}

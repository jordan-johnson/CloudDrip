using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDrip.Core.Writer {
	/// <summary>
	/// MultiWriter allows me to use both the console and a textbox to write
	/// </summary>
	public class MultiWriter : TextWriter {
		private List<TextWriter> _writers;

		public MultiWriter(TextBox textbox) {
			_writers = new List<TextWriter>();

			Add(Console.Out);
			Add(new TextBoxWriter(textbox));
		}

		public void Add(TextWriter writer) {
			_writers.Add(writer);
		}

		public override void Write(char value) {
			foreach(TextWriter writer in _writers) {
				writer.Write(value);
			}
		}

		public override void Write(string value) {
			foreach(TextWriter writer in _writers) {
				writer.Write(value);
			}
		}

		public override void Flush() {
			foreach(TextWriter writer in _writers) {
				/**
				 * This doesn't clear the console (fine by me)
				 * but clears the textbox through TextBoxWriter's
				 * implementation of Flush()
				 */
				writer.Flush();
			}
		}

		public override void Close() {
			foreach(TextWriter writer in _writers) {
				writer.Close();
			}
		}

		public override Encoding Encoding {
			get {
				return Encoding.ASCII;
			}
		}
	}
}

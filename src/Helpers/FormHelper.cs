using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudDrip.Helpers {
	public class FormHelper {
		/// <summary>
		/// Current form target
		/// </summary>
		private Form _form;

		/// <summary>
		/// Child forms
		/// </summary>
		private List<Form> _children;

		/// <summary>
		/// Assigns form and initializes child form list
		/// </summary>
		/// <param name="form"></param>
		public FormHelper(Form form, Form parent = null) {
			_form = form;
			_children = new List<Form>();

			Parent = parent;
		}

		/// <summary>
		/// Parent form
		/// </summary>
		public dynamic Parent {get;set;}

		/// <summary>
		/// Add child form to list
		/// </summary>
		/// <param name="form"></param>
		public void AddChild(Form form) {
			_children.Add(form);
		}

		/// <summary>
		/// Generic form return
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Form GetChild(string name) {
			Form find = _children.Find(x => x.Name == name);

			return find;
		}

		/// <summary>
		/// Resets fields to make sure dialog looks new
		/// </summary>
		/// <param name="name"></param>
		public void SafeToggleChild(string name) {
			Form child = GetChild(name);
			
			ResetFields(child);

			child.ShowDialog(_form);
		}

		/// <summary>
		/// Loops through all possible form controls and sets default value
		/// </summary>
		/// <param name="form"></param>
		public void ResetFields(Form form) {
			foreach(Control c in form.Controls) {
				if(c is TextBox) {
					TextBox textbox = (TextBox)c;
					textbox.Text = null;
				}

				if(c is DateTimePicker) {
					DateTimePicker picker = (DateTimePicker)c;
					picker.Value = DateTime.Now;
				}
			}
		}

		/// <summary>
		/// Centers form and disables maximize window option
		/// </summary>
		public void Defaults() {
			Center();
			DisableMaximize();
		}

		/// <summary>
		/// Positions the window to the center of the screen
		/// </summary>
		public void Center() {
			_form.StartPosition = FormStartPosition.CenterScreen;
			_form.FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		/// <summary>
		/// Disable maximize window option
		/// </summary>
		public void DisableMaximize() {
			_form.MaximizeBox = false;
		}

		/// <summary>
		/// If control's text value is empty, return false
		/// </summary>
		/// <param name="controls">List of controls</param>
		/// <returns>True if successful, false if a control value is empty</returns>
		public bool VerifyFields(params Control[] controls) {
			foreach(Control c in controls) {
				if(c.Text == String.Empty) {
					return false;
				}
			}

			return true;
		}
	}
}

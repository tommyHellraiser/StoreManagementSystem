using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using StoreManagementSystem.Classes.Users;

namespace StoreManagementSystem.Forms.Users
{
	public partial class UserLogin : Form
	{
		internal User? user;
		internal string? username;
		internal string? password;
		public UserLogin()
		{
			InitializeComponent();
		}

		private void btnLoginConfirm_Click(object sender, EventArgs e)
		{			
			//	Validate input and retry if invalid
			if (!ValidateInput())
			{
				return;
			}

			//	Assign input to this class' fields
			this.username = txtUsernameInput.Text;
			this.password = txtPasswordInput.Text;

			//	Validate with db that user exists
			User? user = User.GetFromUsername(this.username);
			if (user == null)
			{
				ShowWarningBox("Invalid user. Please try again");
				return;
			}

			//	Validate with User object that password matches
			if (!user.IsPasswordValid(this.password))
			{
				ShowWarningBox("Invalid password. Try again");
				return;
			}

			//	Save user and close this form
			this.user = user;
			this.Close();
		}

		private void ShowWarningBox(string message)
		{
			MessageBox.Show(
				message,
				"Warning",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Validates the required fields were entered and are not either null or empty
		/// </summary>
		/// <returns></returns>
		private bool ValidateInput()
		{
			//	Validate username was input
			bool valid_input = true;
			if (txtUsernameInput.Text.IsNullOrEmpty())
			{
				lblUsernameRequired.Visible = true;
				valid_input = false;
			}
			else
			{
				lblUsernameRequired.Visible = false;
			}

			//	Validate password was input
			if (txtPasswordInput.Text.IsNullOrEmpty())
			{
				lblPasswordRequired.Visible = true;
				valid_input = false;
			}
			else
			{
				lblPasswordRequired.Visible = false;
			}
			return valid_input;
		}
	}
}

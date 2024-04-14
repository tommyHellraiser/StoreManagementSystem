using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreManagementSystem.Classes.Users;

namespace StoreManagementSystem.Forms.Users
{
	public partial class UserLogin : Form
	{
		internal bool logged_in;
		internal User? user;
		public UserLogin()
		{
			InitializeComponent();
			this.logged_in = false;
		}

		private void btnLoginConfirm_Click(object sender, EventArgs e)
		{
			//	Validate username and password were input

			//	Validate with db that user exists

			//	Validate with User object that password matches

			//	Save user and close this form
		}
	}
}

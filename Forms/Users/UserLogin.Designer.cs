namespace StoreManagementSystem.Forms.Users
{
	partial class UserLogin
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			txtUsernameInput = new TextBox();
			lblUsername = new Label();
			lblPassword = new Label();
			txtPasswordInput = new TextBox();
			btnLoginConfirm = new Button();
			lblUsernameRequired = new Label();
			lblPasswordRequired = new Label();
			SuspendLayout();
			// 
			// txtUsernameInput
			// 
			txtUsernameInput.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtUsernameInput.Location = new Point(67, 65);
			txtUsernameInput.Name = "txtUsernameInput";
			txtUsernameInput.Size = new Size(380, 33);
			txtUsernameInput.TabIndex = 0;
			txtUsernameInput.TextAlign = HorizontalAlignment.Center;
			// 
			// lblUsername
			// 
			lblUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblUsername.Location = new Point(110, 31);
			lblUsername.Name = "lblUsername";
			lblUsername.Size = new Size(287, 31);
			lblUsername.TabIndex = 1;
			lblUsername.Text = "Username:";
			lblUsername.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblPassword
			// 
			lblPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblPassword.Location = new Point(110, 124);
			lblPassword.Name = "lblPassword";
			lblPassword.Size = new Size(287, 31);
			lblPassword.TabIndex = 3;
			lblPassword.Text = "Password:";
			lblPassword.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// txtPasswordInput
			// 
			txtPasswordInput.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtPasswordInput.Location = new Point(67, 158);
			txtPasswordInput.Name = "txtPasswordInput";
			txtPasswordInput.PasswordChar = '*';
			txtPasswordInput.Size = new Size(380, 33);
			txtPasswordInput.TabIndex = 1;
			txtPasswordInput.TextAlign = HorizontalAlignment.Center;
			// 
			// btnLoginConfirm
			// 
			btnLoginConfirm.Location = new Point(132, 218);
			btnLoginConfirm.Name = "btnLoginConfirm";
			btnLoginConfirm.Size = new Size(245, 57);
			btnLoginConfirm.TabIndex = 2;
			btnLoginConfirm.Text = "Confirm!";
			btnLoginConfirm.UseVisualStyleBackColor = true;
			btnLoginConfirm.Click += btnLoginConfirm_Click;
			// 
			// lblUsernameRequired
			// 
			lblUsernameRequired.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblUsernameRequired.ForeColor = Color.Red;
			lblUsernameRequired.Location = new Point(67, 31);
			lblUsernameRequired.Name = "lblUsernameRequired";
			lblUsernameRequired.Size = new Size(97, 31);
			lblUsernameRequired.TabIndex = 4;
			lblUsernameRequired.Text = "*Required";
			lblUsernameRequired.TextAlign = ContentAlignment.MiddleCenter;
			lblUsernameRequired.Visible = false;
			// 
			// lblPasswordRequired
			// 
			lblPasswordRequired.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblPasswordRequired.ForeColor = Color.Red;
			lblPasswordRequired.Location = new Point(67, 124);
			lblPasswordRequired.Name = "lblPasswordRequired";
			lblPasswordRequired.Size = new Size(97, 31);
			lblPasswordRequired.TabIndex = 5;
			lblPasswordRequired.Text = "*Required";
			lblPasswordRequired.TextAlign = ContentAlignment.MiddleCenter;
			lblPasswordRequired.Visible = false;
			// 
			// UserLogin
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(508, 301);
			Controls.Add(lblPasswordRequired);
			Controls.Add(lblUsernameRequired);
			Controls.Add(btnLoginConfirm);
			Controls.Add(lblPassword);
			Controls.Add(txtPasswordInput);
			Controls.Add(lblUsername);
			Controls.Add(txtUsernameInput);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "UserLogin";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Login";
			TopMost = true;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtUsernameInput;
		private Label lblUsername;
		private Label lblPassword;
		private TextBox txtPasswordInput;
		private Button btnLoginConfirm;
		private Label lblUsernameRequired;
		private Label lblPasswordRequired;
	}
}
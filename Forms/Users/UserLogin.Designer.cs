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
			label1 = new Label();
			label2 = new Label();
			txtPasswordInput = new TextBox();
			btnLoginConfirm = new Button();
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
			// label1
			// 
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(110, 31);
			label1.Name = "label1";
			label1.Size = new Size(287, 31);
			label1.TabIndex = 1;
			label1.Text = "Username:";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(110, 124);
			label2.Name = "label2";
			label2.Size = new Size(287, 31);
			label2.TabIndex = 3;
			label2.Text = "Password:";
			label2.TextAlign = ContentAlignment.MiddleCenter;
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
			// UserLogin
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(508, 301);
			Controls.Add(btnLoginConfirm);
			Controls.Add(label2);
			Controls.Add(txtPasswordInput);
			Controls.Add(label1);
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
		private Label label1;
		private Label label2;
		private TextBox txtPasswordInput;
		private Button btnLoginConfirm;
	}
}
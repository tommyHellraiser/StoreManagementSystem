namespace StoreManagementSystem
{
	partial class Home
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			picDbConnStatus = new PictureBox();
			lblClock = new Label();
			btnResetDatabase = new CustomButton.HellButton();
			btnUsersManagement = new CustomButton.HellButton();
			btnNewSale = new CustomButton.HellButton();
			btnItemsManagement = new CustomButton.HellButton();
			btnBalancesManagement = new CustomButton.HellButton();
			lblUserLoggedIn = new Label();
			((System.ComponentModel.ISupportInitialize)picDbConnStatus).BeginInit();
			SuspendLayout();
			// 
			// picDbConnStatus
			// 
			picDbConnStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			picDbConnStatus.BackgroundImageLayout = ImageLayout.Stretch;
			picDbConnStatus.Image = Properties.Resources.database_conn_error;
			picDbConnStatus.InitialImage = Properties.Resources.database_conn_error;
			picDbConnStatus.Location = new Point(1037, 614);
			picDbConnStatus.Name = "picDbConnStatus";
			picDbConnStatus.Size = new Size(35, 35);
			picDbConnStatus.SizeMode = PictureBoxSizeMode.StretchImage;
			picDbConnStatus.TabIndex = 0;
			picDbConnStatus.TabStop = false;
			// 
			// lblClock
			// 
			lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblClock.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblClock.Location = new Point(816, 9);
			lblClock.Name = "lblClock";
			lblClock.Size = new Size(256, 56);
			lblClock.TabIndex = 1;
			lblClock.Text = "--/--/-- --:--";
			lblClock.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnResetDatabase
			// 
			btnResetDatabase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnResetDatabase.BackColor = Color.IndianRed;
			btnResetDatabase.BackgroundColor = Color.IndianRed;
			btnResetDatabase.BorderColor = Color.Red;
			btnResetDatabase.BorderRadius = 30;
			btnResetDatabase.BorderSize = 4;
			btnResetDatabase.FlatAppearance.BorderSize = 0;
			btnResetDatabase.FlatStyle = FlatStyle.Flat;
			btnResetDatabase.ForeColor = Color.WhiteSmoke;
			btnResetDatabase.Location = new Point(12, 605);
			btnResetDatabase.Name = "btnResetDatabase";
			btnResetDatabase.Size = new Size(116, 44);
			btnResetDatabase.TabIndex = 2;
			btnResetDatabase.Text = "Reset Database!";
			btnResetDatabase.TextColor = Color.WhiteSmoke;
			btnResetDatabase.UseVisualStyleBackColor = false;
			btnResetDatabase.Click += btnResetDatabase_Click;
			// 
			// btnUsersManagement
			// 
			btnUsersManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnUsersManagement.BackColor = Color.RoyalBlue;
			btnUsersManagement.BackgroundColor = Color.RoyalBlue;
			btnUsersManagement.BorderColor = Color.MediumBlue;
			btnUsersManagement.BorderRadius = 40;
			btnUsersManagement.BorderSize = 4;
			btnUsersManagement.FlatAppearance.BorderSize = 0;
			btnUsersManagement.FlatStyle = FlatStyle.Flat;
			btnUsersManagement.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnUsersManagement.ForeColor = Color.WhiteSmoke;
			btnUsersManagement.Location = new Point(624, 104);
			btnUsersManagement.Name = "btnUsersManagement";
			btnUsersManagement.Size = new Size(377, 152);
			btnUsersManagement.TabIndex = 3;
			btnUsersManagement.Text = "Users Management";
			btnUsersManagement.TextColor = Color.WhiteSmoke;
			btnUsersManagement.UseVisualStyleBackColor = false;
			// 
			// btnNewSale
			// 
			btnNewSale.BackColor = Color.ForestGreen;
			btnNewSale.BackgroundColor = Color.ForestGreen;
			btnNewSale.BorderColor = Color.DarkGreen;
			btnNewSale.BorderRadius = 40;
			btnNewSale.BorderSize = 4;
			btnNewSale.FlatAppearance.BorderSize = 0;
			btnNewSale.FlatStyle = FlatStyle.Flat;
			btnNewSale.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnNewSale.ForeColor = Color.WhiteSmoke;
			btnNewSale.Location = new Point(99, 104);
			btnNewSale.Name = "btnNewSale";
			btnNewSale.Size = new Size(377, 152);
			btnNewSale.TabIndex = 4;
			btnNewSale.Text = "New Sale";
			btnNewSale.TextColor = Color.WhiteSmoke;
			btnNewSale.UseVisualStyleBackColor = false;
			// 
			// btnItemsManagement
			// 
			btnItemsManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnItemsManagement.BackColor = Color.Goldenrod;
			btnItemsManagement.BackgroundColor = Color.Goldenrod;
			btnItemsManagement.BorderColor = Color.Chocolate;
			btnItemsManagement.BorderRadius = 40;
			btnItemsManagement.BorderSize = 4;
			btnItemsManagement.FlatAppearance.BorderSize = 0;
			btnItemsManagement.FlatStyle = FlatStyle.Flat;
			btnItemsManagement.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnItemsManagement.ForeColor = Color.WhiteSmoke;
			btnItemsManagement.Location = new Point(99, 377);
			btnItemsManagement.Name = "btnItemsManagement";
			btnItemsManagement.Size = new Size(377, 152);
			btnItemsManagement.TabIndex = 5;
			btnItemsManagement.Text = "Items Management";
			btnItemsManagement.TextColor = Color.WhiteSmoke;
			btnItemsManagement.UseVisualStyleBackColor = false;
			// 
			// btnBalancesManagement
			// 
			btnBalancesManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnBalancesManagement.BackColor = Color.DarkGray;
			btnBalancesManagement.BackgroundColor = Color.DarkGray;
			btnBalancesManagement.BorderColor = Color.DimGray;
			btnBalancesManagement.BorderRadius = 40;
			btnBalancesManagement.BorderSize = 4;
			btnBalancesManagement.FlatAppearance.BorderSize = 0;
			btnBalancesManagement.FlatStyle = FlatStyle.Flat;
			btnBalancesManagement.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnBalancesManagement.ForeColor = Color.WhiteSmoke;
			btnBalancesManagement.Location = new Point(624, 377);
			btnBalancesManagement.Name = "btnBalancesManagement";
			btnBalancesManagement.Size = new Size(377, 152);
			btnBalancesManagement.TabIndex = 6;
			btnBalancesManagement.Text = "Balances Management";
			btnBalancesManagement.TextColor = Color.WhiteSmoke;
			btnBalancesManagement.UseVisualStyleBackColor = false;
			// 
			// lblUserLoggedIn
			// 
			lblUserLoggedIn.AutoSize = true;
			lblUserLoggedIn.BorderStyle = BorderStyle.Fixed3D;
			lblUserLoggedIn.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblUserLoggedIn.Location = new Point(12, 9);
			lblUserLoggedIn.Name = "lblUserLoggedIn";
			lblUserLoggedIn.Size = new Size(102, 47);
			lblUserLoggedIn.TabIndex = 7;
			lblUserLoggedIn.Text = "User: ";
			lblUserLoggedIn.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// Home
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(1084, 661);
			Controls.Add(lblUserLoggedIn);
			Controls.Add(btnBalancesManagement);
			Controls.Add(btnItemsManagement);
			Controls.Add(btnNewSale);
			Controls.Add(btnUsersManagement);
			Controls.Add(btnResetDatabase);
			Controls.Add(lblClock);
			Controls.Add(picDbConnStatus);
			MinimumSize = new Size(960, 600);
			Name = "Home";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Home";
			((System.ComponentModel.ISupportInitialize)picDbConnStatus).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox picDbConnStatus;
		private Label lblClock;
		private CustomButton.HellButton btnResetDatabase;
		private CustomButton.HellButton btnUsersManagement;
		private CustomButton.HellButton btnNewSale;
		private CustomButton.HellButton btnItemsManagement;
		private CustomButton.HellButton btnBalancesManagement;
		private Label lblUserLoggedIn;
	}
}

﻿namespace StoreManagementSystem
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
			((System.ComponentModel.ISupportInitialize)picDbConnStatus).BeginInit();
			SuspendLayout();
			// 
			// picDbConnStatus
			// 
			picDbConnStatus.Anchor = AnchorStyles.None;
			picDbConnStatus.BackgroundImageLayout = ImageLayout.Stretch;
			picDbConnStatus.Image = Properties.Resources.database_conn_error;
			picDbConnStatus.InitialImage = Properties.Resources.database_conn_error;
			picDbConnStatus.Location = new Point(753, 403);
			picDbConnStatus.Name = "picDbConnStatus";
			picDbConnStatus.Size = new Size(35, 35);
			picDbConnStatus.SizeMode = PictureBoxSizeMode.StretchImage;
			picDbConnStatus.TabIndex = 0;
			picDbConnStatus.TabStop = false;
			// 
			// lblClock
			// 
			lblClock.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblClock.Location = new Point(532, 9);
			lblClock.Name = "lblClock";
			lblClock.Size = new Size(256, 56);
			lblClock.TabIndex = 1;
			lblClock.Text = "--/--/-- --:--";
			lblClock.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Home
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(lblClock);
			Controls.Add(picDbConnStatus);
			Name = "Home";
			Text = "Home";
			((System.ComponentModel.ISupportInitialize)picDbConnStatus).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox picDbConnStatus;
		private Label lblClock;
	}
}

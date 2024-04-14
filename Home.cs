
using StoreManagementSystem.Classes.General;
using StoreManagementSystem.Classes.Users;
using StoreManagementSystem.Forms.Users;
using StoreManagementSystem.Properties;

//	Callbacks
delegate void SetClockCallback(DateTime datetime);
delegate void SetButtonsStatusCallback(bool enabled);


namespace StoreManagementSystem
{
	public partial class Home : Form
	{

		private User user;

		/// Class constructor
		public Home()
		{
			InitializeComponent();

			LoadInitConfig();

			while (!DbConn.IsDbConnected())
			{
				Thread.Sleep(100);
			}

			if (!FirstLogin())
			{
				Environment.Exit(0);
			}
		}

		#region Db Properties
		/// Reconnection count to determine when to change the image from Reconnecting to Error
		private int db_reconnection_count = 0;

		/// Image resources for setting db status image in Home screen
		private Bitmap[] db_status_imgs = [Resources.database_conn_error, Resources.database_conn_in_progress, Resources.database_conn_ok];

		/// Connection status to set db connection status image in home screen
		public DbConnStatus connection_status;
		public DbConnStatus ConnectionStatus
		{
			get
			{
				return connection_status;
			}
			set
			{
				switch (value)
				{
					case DbConnStatus.Error:
						picDbConnStatus.Image = this.db_status_imgs[(int)DbConnStatus.Error];
						break;
					case DbConnStatus.Connecting:
						picDbConnStatus.Invalidate();
						picDbConnStatus.Image = this.db_status_imgs[(int)DbConnStatus.Connecting];
						break;
					case DbConnStatus.Ok:
						picDbConnStatus.Image = this.db_status_imgs[(int)DbConnStatus.Ok];
						break;
					default:
						picDbConnStatus.Image = this.db_status_imgs[(int)DbConnStatus.Error];
						break;
				}

				connection_status = value;
			}
		}

		#endregion

		#region Clock properties

		private DateTime current_time;
		private DateTime CurrentTime
		{
			get
			{
				return this.current_time;
			}
			set
			{
				this.current_time = value;
				SetClock(this.current_time);
			}
		}

		/// <summary>
		/// Sets the app clock or invokes a callback if invoke is required by the spawned object lblClock
		/// </summary>
		/// <param name="datetime"></param>
		private void SetClock(DateTime datetime)
		{
			if (this.lblClock.InvokeRequired)
			{
				SetClockCallback call = new SetClockCallback(SetClock);
				this.Invoke(call, [datetime]);
			}
			else
			{
				lblClock.Text = this.current_time.ToString("yy/MM/dd hh:mm");
			}
		}

		#endregion

		#region System Methods

		private void LoadInitConfig()
		{
			//	Initialize and instantiate logger
			Logger.Init();
			Logger logger = Logger.Instance;

			//	Logger initialization
			try
			{
				Config.LoadFromJson();
				logger.Log("Config loaded OK", LogLevel.Info);
			}
			catch (Exception ex)
			{
				logger.Log($"Error loading configuration: {ex.Message}", LogLevel.Error);
				MessageBox.Show(
					"Please check the config.json file for proper parameters",
					"Critical Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				Environment.Exit(-1);
			}

			//	Db connection initialization
			try
			{
				this.ConnectionStatus = DbConnStatus.Connecting;

				if (!DbConn.Init())
				{
					//	Trigger retry connection here
					this.ConnectionStatus = DbConnStatus.Connecting;
					while (!DbConn.IsDbConnected())
					{
						Thread.Sleep(100);
					}
				}

				this.ConnectionStatus = DbConnStatus.Ok;
			}
			catch (Exception ex)
			{
				logger.Log($"Couldn't connect to database: {ex.Message}", LogLevel.Warning);
			}

			//	Start cron jobs
			Task.Run(() => DbHealth());
			Task.Run(() => ClockHandler());
		}

		/// <summary>
		/// Calls login form to execute user login, and saves the logged in user in global class property
		/// </summary>
		/// <returns>
		/// True if login was successful, false if user closed form
		/// </returns>
		private bool FirstLogin()
		{
			Logger logger = Logger.Instance;

			try
			{
				//	Display login box
				UserLogin login_form = new();
				login_form.ShowDialog();

				//	If user closed dialog, close application
				if (login_form.user == null)
				{
					MessageBox.Show(
						"Cannot start application if a user is not logged in",
						"Login required",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					return false;
				}

				//	Otherwise, user should be logged in by now
				this.user = login_form.user;

				//	Set the username in home screen label
				lblUserLoggedIn.Text += $" {this.user.username}";

				return true;
			}
			catch (Exception ex)
			{
				logger.Log($"Error logging user in: {ex.Message}", LogLevel.Error);
				return false;
			}
		}

		#endregion

		#region Cron jobs

		private void DbHealth()
		{
			while (true)
			{
				if (!DbConn.IsDbConnected())
				{
					if (this.db_reconnection_count <= 50)
					{
						SetButtonsStatus(false);
						this.db_reconnection_count++;
						this.ConnectionStatus = DbConnStatus.Connecting;

					}
					else
					{
						SetButtonsStatus(false);
						this.db_reconnection_count = 51;
						this.ConnectionStatus = DbConnStatus.Error;
					}
				}
				else
				{
					SetButtonsStatus(true);
					this.db_reconnection_count = 0;
					this.ConnectionStatus = DbConnStatus.Ok;
				}

				Thread.Sleep(200);
			}
		}

		private void ClockHandler()
		{
			while (true)
			{
				this.CurrentTime = DateTime.Now;

				//	10s sleeps to update time. No seconds to update, only year, month, day, hours and minutes
				Thread.Sleep(5000);
			}
		}

		#endregion

		#region System Methods

		/// <summary>
		/// Disables all buttons in home page. Intended to be used only when database loses connection
		/// </summary>
		private void SetButtonsStatus(bool enabled)
		{
			if (this.btnResetDatabase.InvokeRequired)
			{
				SetButtonsStatusCallback call = new SetButtonsStatusCallback(SetButtonsStatus);
				this.btnResetDatabase.Invoke(call, [enabled]);
			}
			else
			{
				this.btnResetDatabase.Enabled = enabled;
			}
		}

		#endregion

		#region Handlers

		private void btnResetDatabase_Click(object sender, EventArgs e)
		{
			Logger logger = Logger.Instance;
			StreamReader reader = new StreamReader("../../../Sql/schema_reset.sql");
			string schema_reset = reader.ReadToEnd();

			try
			{
				DbConn.SchemaReset(schema_reset);
				logger.Log("Database reset successfully!", LogLevel.Info);
			}
			catch (Exception ex)
			{
				logger.Log($"Error executing schema reset!: {ex.Message}", LogLevel.Error);
			}
		}

		#endregion
	}

	public enum DbConnStatus
	{
		Error,
		Connecting,
		Ok,
	}
}

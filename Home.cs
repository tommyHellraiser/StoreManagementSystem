using StoreManagementSystem.Classes;

namespace StoreManagementSystem
{
	public partial class Home : Form
	{
		public Home()
		{
			InitializeComponent();


			Task.Run(() => LoadInitConfig());
		}

		private void LoadInitConfig()
		{
			Logger.Init();
			Logger logger = Logger.Instance;
			//logger.Log("Sup, logger test here");
			logger.Log("Sup, logger test here", LogLevel.Debug);
			logger.Log("Sup, logger test here", LogLevel.Info);
			logger.Log("Sup, logger test here", LogLevel.Warning);
			logger.Log("Sup, logger test here", LogLevel.Error);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace StoreManagementSystem.Classes
{
	public static class Config
	{

		public static string DataSource { get; set; }
		public static string InitialCatalog { get; set; }
		public static bool IntegratedSecurity { get; set; }
		public static bool TrustServerCertificate { get; set; }

		public class Rootobject
		{
			public Dbconfig DbConfig { get; set; }
			//public Otherconfigs OtherConfigs { get; set; }

			internal bool Validate()
			{
				return this.DbConfig.Validate();
			}
		}

		public class Dbconfig
		{
			public string? DataSource { get; set; }
			public string? InitialCatalog { get; set; }
			public bool? IntegratedSecurity { get; set; }
			public bool? TrustServerCertificate { get; set; }
			internal bool Validate()
			{
				//	Checking nullability
				if (this.DataSource == null || this.InitialCatalog == null || this.IntegratedSecurity == null || this.TrustServerCertificate == null)
				{
					return false;
				}

				// Checking completion of fields
				if (this.DataSource == "" || this.InitialCatalog == "")
				{
					return false;
				}
				return true;
			}
		}

		//public class Otherconfigs
		//{

		//}

		///	Load config from json file
		public static void LoadFromJson()
		{
			//	Conditional compilation path
			#if DEBUG
				string config_json_path = "../../../config/config.json";
			#else
				string config_json_path = "";
			#endif

			//	Attempt to load from file
			using (StreamReader reader = new StreamReader(config_json_path))
			{
				string? json = reader.ReadToEnd();
				if (json == null)
				{
					throw new NullReferenceException("No config.json was found in specified directory");
				}
				Rootobject? configuration = JsonSerializer.Deserialize<Rootobject>(json);
				if (configuration == null)
				{
					throw new ApplicationException("Couldn't load configuration from config.json file");
				}
				if (!configuration.Validate())
				{
					throw new ApplicationException("Coudln't load required fields from config.json");
				}

				//	Set the values and return 
				DataSource = configuration.DbConfig.DataSource!;
				InitialCatalog = configuration.DbConfig.InitialCatalog!;
				IntegratedSecurity = (bool)configuration.DbConfig.IntegratedSecurity!;
				TrustServerCertificate = (bool)configuration.DbConfig.TrustServerCertificate!;
			}
		}
	}
}

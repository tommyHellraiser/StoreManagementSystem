using StoreManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StoreManagementSystem.Classes.General
{
	internal static class DbConn
	{
		public static SqlConnectionStringBuilder conn_builder;

		public static bool Init()
		{
			Logger logger = Logger.Instance;

			try
			{
				SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
				builder.DataSource = Config.DataSource;
				builder.InitialCatalog = Config.InitialCatalog;
				builder.IntegratedSecurity = Config.IntegratedSecurity;
				builder.TrustServerCertificate = Config.TrustServerCertificate;
				builder.ConnectTimeout = 2;

				conn_builder = builder;

				SqlConnection conn = new SqlConnection(builder.ConnectionString);
				conn.Open();

				logger.Log("Db Connection established", LogLevel.Info);

				conn.Close();

				return true;
			}
			catch (Exception ex)
			{
				logger.Log($"Couldn't connect to database: {ex.Message}", LogLevel.Warning);
				return false;
			}
		}

		public static SqlConnection GetOpenConn()
		{
			SqlConnection conn = new SqlConnection(conn_builder.ConnectionString);
			//	If db connection is open when we're trying to open it, we need to wait until it's closed
			while (conn.State == System.Data.ConnectionState.Open)
			{
				Thread.Sleep(100);
			}
			conn.Open();

			return conn;
		}

		public static bool IsDbConnected()
		{
			
			SqlConnection conn = new SqlConnection(conn_builder.ConnectionString);

			try
			{
				conn.Open();
			}
			catch
			{
				return false;
			}
			
			
			if (conn.State == System.Data.ConnectionState.Open)
			{
				try
				{
					conn.Close();
					return true;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				try
				{
					conn.Close();
					
				}
				catch
				{
					
				}
				return false;
			}
		}

		#region Queries Execution

		public static bool SchemaReset(string query)
		{
			SqlConnection conn = GetOpenConn();
			SqlCommand cmd = new SqlCommand(query, conn);

			int ar = cmd.ExecuteNonQuery();

			conn.Close();

			return ar > 0;
		}

		#endregion
	}
}



/*

//	Set db conn status image as in progress
			this.pbxDbConnStatus.Image = Resources.database_conn_in_progress;
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = Config.data_source;
			builder.InitialCatalog = Config.initial_catalog;
			builder.IntegratedSecurity = Config.integrated_security;
			builder.TrustServerCertificate = Config.trust_server_certificate;

			SqlConnection conn = new SqlConnection(builder.ConnectionString);
			conn.Open();

			//	Set db conn status image as Ok
			this.pbxDbConnStatus.Image = Resources.database_conn_ok;


*/
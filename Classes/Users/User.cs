using Microsoft.Data.SqlClient;
using StoreManagementSystem.Classes.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Classes.Users
{
	internal class User
	{
		internal int? id;
		internal string? name;
		internal string? last_name;
		internal string? document;
		internal string? username;
		internal string? pass;
		internal UserLevel level;

		/// <summary>
		/// Class constructor used for fetching from database. ID will not be null and pass will be hashed
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="last_name"></param>
		/// <param name="document"></param>
		/// <param name="username"></param>
		/// <param name="hashed_pass"></param>
		/// <param name="level"></param>
		internal User(int id, string name, string last_name, string document, string username, string hashed_pass, UserLevel level)
		{
			this.id = id;
			this.name = name;
			this.last_name = last_name;
			this.document = document;
			this.username = username;
			this.pass = hashed_pass;
			this.level = level;
		}

		/// <summary>
		/// Class constructor for any use other than database fetching. ID is null because we don't know the ID in database yet, and
		/// password comes unhashed but gets hashed when constructing the class
		/// </summary>
		/// <param name="name"></param>
		/// <param name="last_name"></param>
		/// <param name="document"></param>
		/// <param name="username"></param>
		/// <param name="unhashed_pass"></param>
		/// <param name="level"></param>
		internal User(string name, string last_name, string document, string username, string unhashed_pass, UserLevel level)
		{
			this.id = null;
			this.name = name;
			this.last_name = last_name;
			this.document = document;
			this.username = username;
			this.pass = PassHasher(unhashed_pass);
			this.level = level;
		}

		#region Class Methods

		/// <summary>
		/// Takes a raw password in string format and hashes using SHA256. Returns the hased password in hex format with a 
		/// length of 64 chars (256-bit)
		/// </summary>
		/// <param name="unhashed_pass"></param>
		/// <returns></returns>
		internal string PassHasher(string unhashed_pass)
		{
			//Hash a pass in C#
			SHA256 hasher = SHA256.Create();

			byte[] hashed_bytes = hasher.ComputeHash(Encoding.ASCII.GetBytes(unhashed_pass));

			StringBuilder builder = new StringBuilder();

			foreach (byte letter in hashed_bytes)
			{
				builder.Append(letter.ToString("x2"));
			}

			return builder.ToString();
		}

		/// <summary>
		/// This method will take the user fetched from database and compare the hashed pass (obtained from row in database)
		/// to the one sent by parameter
		/// </summary>
		/// <param name="unhashed_pass"></param>
		/// <returns></returns>
		internal bool IsPasswordValid(string unhashed_pass)
		{
			return this.pass == PassHasher(unhashed_pass);
		}

		#endregion

		#region Queries Methods

		/// <summary>
		/// Fetches user from database filtering by username
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		internal static User? GetFromUsername(string username)
		{
			SqlConnection conn = DbConn.GetOpenConn();

			string query = "SELECT * FROM users WHERE username = @username;";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@username", username);
			SqlDataReader reader = cmd.ExecuteReader();

			User? user = FromRow(reader);

			conn.Close();

			return user;
		}

		/// <summary>
		/// Extracts a User nullable object from database reader
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static User? FromRow(SqlDataReader reader)
		{
			if(reader.Read())
			{
				User user = new User(
					(int)reader["ID"],
					(string)reader["name"],
					(string)reader["last_name"],
					(string)reader["document"],
					(string)reader["username"],
					(string)reader["pass"],
					(UserLevel)(byte)reader["level"]);

				return user;
			}

			return null;
		}

		#endregion
	}

	public enum UserLevel
	{
		Employee = 0,
		Admin = 1,
		Owner = 2,
	}
}

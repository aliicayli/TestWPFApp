using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.Sql;

namespace TestWPFApp
{
    public class DBConnection
    {
        public static string DBPath = @"Data Source =C:\\Users\\Ali\\Desktop\\test.db;Version=3";
        public static string debugText;
        public static void ConnectionTest()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        //connection.Open();
                        //string query = $"SELECT surname FROM Users WHERE name = '{"testName2"}'";

                        //SQLiteCommand sQLiteCommand = new SQLiteCommand(query,connection);
                        //SQLiteDataReader reader = sQLiteCommand.ExecuteReader();
                        //while (reader.Read())
                        //{
                        //    debugText = reader.GetString(0);
                        //}
                        connection.Open();
                        string query = "INSERT INTO Users (user_name, passwprd) VALUES (@userName, @passeord)";

                        SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                        //sQLiteCommand.Parameters.AddWithValue("@id", 5);
                        sQLiteCommand.Parameters.AddWithValue("@name", "isim");
                        sQLiteCommand.Parameters.AddWithValue("@surname", "soyisim");
                        sQLiteCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public static bool AddNewUser(string name, string password, string email, string phoneNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 1 FROM Users WHERE user_name = @userName";
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                    sQLiteCommand.Parameters.AddWithValue("@userName", name);
                    sQLiteCommand.Parameters.AddWithValue("@password", password);
                    sQLiteCommand.Parameters.AddWithValue("@email", email);
                    sQLiteCommand.Parameters.AddWithValue("@phone_number", phoneNumber);
                    object result = sQLiteCommand.ExecuteScalar();
                    if (result == null) // name değeri yoksa
                    {
                        query = "INSERT INTO Users (user_name, password,email,phone_number) VALUES (@userName, @password,@email,@phone_number)";
                        sQLiteCommand.CommandText = query;
                        sQLiteCommand.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public static bool Login(string name, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT password FROM Users WHERE user_name=@userName";
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                    sQLiteCommand.Parameters.AddWithValue("@userName", name);
                    sQLiteCommand.Parameters.AddWithValue("@password", password);
                    object result = sQLiteCommand.ExecuteScalar(); //password
                    if (result != null && result.ToString() == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

    }
}

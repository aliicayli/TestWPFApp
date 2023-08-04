using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Data.Sql;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace TestWPFApp
{
    public class DBConnection
    {
        public static string DBPath = @"Data Source =C:\\Users\\Ali\\Desktop\\test.db;Version=3"; // Path for our database
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

        public static bool AddNewUser(string name, string password, string email, string phoneNumber) // Function for new user
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath)) // Reference for connection SQLite database
            {
                try
                {
                    connection.Open(); // open connection
                    string query = "SELECT 1 FROM Users WHERE user_name = @userName"; // Checking if there is a record with the same name
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection); // new sQLiteCommand for query
                    sQLiteCommand.Parameters.AddWithValue("@userName", name); // userName is equal to name for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@password", password); // password is equal to password for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@email", email); // email is equal to email for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@phone_number", phoneNumber); // phone_number is equal to phoneNumber for database parameter
                    object result = sQLiteCommand.ExecuteScalar(); // execute query for result
                    if (result == null) // Checking name is null ?
                    {
                        query = "INSERT INTO Users (user_name, password,email,phone_number) VALUES (@userName, @password,@email,@phone_number)"; // SQL qurey for Insert new data
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


        public static bool Login(string name, string password) // Function for login control
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath)) // Reference for connection SQLite database
            {
                try
                {
                    connection.Open(); // open connection
                    string query = "SELECT password FROM Users WHERE user_name=@userName"; // Get password of specified name
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                    sQLiteCommand.Parameters.AddWithValue("@userName", name);
                    sQLiteCommand.Parameters.AddWithValue("@password", password);
                    object result = sQLiteCommand.ExecuteScalar(); //password
                    if (result != null && result.ToString() == password) //  It returns true if the entered password is the same as the password in the database.

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

        public static bool AdminLogin(string adminName, string adminPassword) // Function for login control
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath)) // Reference for connection SQLite database
            {
                try
                {
                    connection.Open(); // open connection

                    string query = "SELECT admin_password FROM Admins WHERE admin_name=@adminName"; // Get password of specified name
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                    sQLiteCommand.Parameters.AddWithValue("@adminName", adminName);
                    sQLiteCommand.Parameters.AddWithValue("@admin_password", adminPassword);
                    object result = sQLiteCommand.ExecuteScalar(); //password
                    if (result != null && result.ToString() == adminPassword) //  It returns true if the entered password is the same as the password in the database.

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


        public static void ListAllUsers(DataGrid dataGrid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                connection.Open();
                string query = "SELECT * FROM Users";
                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                SQLiteDataAdapter adaptor = new SQLiteDataAdapter(sQLiteCommand);
                DataTable dataTable = new DataTable("Users");
                adaptor.Fill(dataTable);
                ObservableCollection<Member> members = new ObservableCollection<Member>();

                foreach (DataRow row in dataTable.Rows)
                {
                    members.Add(new Member { UserName = row["user_name"].ToString(), Password = row["password"].ToString(), Email = row["email"].ToString(), PhoneNumber = row["phone_number"].ToString() });
                }

                // dataGrid.ItemsSource = dataTable.DefaultView;
                dataGrid.ItemsSource = members;
            }
        }

        public static bool AddNewAdmin(string adminName, string password, string email, string phoneNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                connection.Open();
                string query = "SELECT 1 FROM Admins WHERE admin_name = @adminName"; // Checking if there is a record with the same name

                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                sQLiteCommand.Parameters.AddWithValue("@adminName", adminName); // userName is equal to name for database parameter
                sQLiteCommand.Parameters.AddWithValue("@password", password); // password is equal to password for database parameter
                sQLiteCommand.Parameters.AddWithValue("@email", email); // email is equal to email for database parameter
                sQLiteCommand.Parameters.AddWithValue("@phone_number", phoneNumber); // phone_number is equal to phoneNumber for database 
                object result = sQLiteCommand.ExecuteScalar(); // execute query for result
                if (result == null) // Checking name is null ?
                {
                    query = "INSERT INTO Admins (admin_name, admin_password,admin_mail,admin_phone_number) VALUES (@adminName, @password,@email,@phone_number)"; // SQL qurey for Insert new data
                    sQLiteCommand.CommandText = query;
                    sQLiteCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void UpdateUser(string userName, string password, string email, string phoneNumber)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                connection.Open();
                string query = "UPDATE Users SET password=@password, email=@email, phone_number=@phone_number WHERE user_name=@userName";
                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                sQLiteCommand.Parameters.AddWithValue("@userName", userName); // userName is equal to name for database parameter
                sQLiteCommand.Parameters.AddWithValue("@password", password); // password is equal to password for database parameter
                sQLiteCommand.Parameters.AddWithValue("@email", email); // email is equal to email for database parameter
                sQLiteCommand.Parameters.AddWithValue("@phone_number", phoneNumber); // phone_number is equal to phoneNumber for database 
                sQLiteCommand.ExecuteNonQuery();
            }
        }

        public static bool DeleteUser(string userName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE user_name=@userName";
                SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                sQLiteCommand.Parameters.AddWithValue("@userName", userName); // userName is equal to name for database 
                int count = Convert.ToInt32(sQLiteCommand.ExecuteScalar());
                if (count > 0)
                {
                    query = "DELETE FROM Users WHERE user_name=@userName";
                    sQLiteCommand = new SQLiteCommand(query, connection);
                    sQLiteCommand.Parameters.AddWithValue("@userName", userName); // userName is equal to name for database 
                    sQLiteCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static bool AddNewLibraryData(string productName, string price, string color) // Function for new user
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBPath)) // Reference for connection SQLite database
            {
                try
                {
                    connection.Open(); // open connection
                    string query = "INSERT INTO TablesForLibrary (productName, price,color) VALUES (@productName, @price,@color)"; // SQL qurey for Insert new data
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection); // new sQLiteCommand for query
                    sQLiteCommand.Parameters.AddWithValue("@productName", productName); // userName is equal to name for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@price", price); // password is equal to password for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@color", color); // email is equal to email for database parameter
                    //object result = sQLiteCommand.ExecuteScalar(); // execute query for result

                    sQLiteCommand.CommandText = query;
                    sQLiteCommand.ExecuteNonQuery();
                    return true;



                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}


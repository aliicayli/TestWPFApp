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
using System.IO;

namespace TestWPFApp
{
    public class DBConnection
    {
        public static string DBPath = @"Data Source =C:\\Users\\Ali\\Desktop\\Databases\\test.db;Version=3"; // Path for our database
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


        public static void AddNewLibraryData(string dataType, string productName, string price, string color, string dataBaseName) // Function for new user
        {
            LibraryUserControl libraryUserControl = new LibraryUserControl();
            string[] libraryDataNames = new string[] { "TablesForLibrary", "ChairsForLibrary", "CupBoardsForLibrary" };
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string connectionString = "Data Source=" + desktopPath + "\\" + dataBaseName + ".db;Version=3;";

            string query = "";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) // Reference for connection SQLite database
            {
                try
                {
                    connection.Open(); // open connection




                    query = "INSERT INTO " + dataType + " (productName, price,color) VALUES (@productName, @price,@color)"; // SQL qurey for Insert new data

                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection); // new sQLiteCommand for query
                    sQLiteCommand.Parameters.AddWithValue("@productName", productName); // userName is equal to name for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@price", price); // password is equal to password for database parameter
                    sQLiteCommand.Parameters.AddWithValue("@color", color); // email is equal to email for database parameter
                                                                            //object result = sQLiteCommand.ExecuteScalar(); // execute query for result

                    sQLiteCommand.CommandText = query;
                    sQLiteCommand.ExecuteNonQuery();






                }
                catch (Exception)
                {
                    throw;
                }
            }


        }
        public static void ListAllLibraryDatas(DataGrid dataGrid, string dataBaseName)
        {
            string[] libraryDataNames = new string[] { "TablesForLibrary", "ChairsForLibrary", "CupBoardsForLibrary" };
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string connectionString = "Data Source=" + desktopPath + "\\" + dataBaseName + ".db;Version=3;";
            ObservableCollection<Library> libraries = new ObservableCollection<Library>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < libraryDataNames.Length; i++)
                {
                    string query = "SELECT * FROM " + libraryDataNames[i];
                    SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter adaptor = new SQLiteDataAdapter(sQLiteCommand);
                    DataTable dataTable = new DataTable(libraryDataNames[i]);
                    adaptor.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        libraries.Add(new Library { ProductName = row["productName"].ToString(), Price = row["price"].ToString(), Color = row["color"].ToString() });
                    }
                }






                // dataGrid.ItemsSource = dataTable.DefaultView;
                dataGrid.ItemsSource = libraries;
            }
        }


        public static void NewDatabase(string dataBaseName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string connectionString = "Data Source=" + desktopPath + "\\Databases\\" + dataBaseName + ".db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            //string[] libraryDataNames = new string[] { "TablesForLibrary", "ChairsForLibrary", "CupBoardsForLibrary" };

            //for (int i = 0; i < libraryDataNames.Length; i++)
            //{
            //    string sql = "CREATE TABLE " + libraryDataNames[i] + " (ID INTEGER PRIMARY KEY, productName TEXT, color TEXT, price TEXT)";
            //    SQLiteCommand command = new SQLiteCommand(sql, connection);
            //    command.ExecuteNonQuery();

            //}

        }

        public static bool CopyDataBase(string dbName, string newDbName)
        {
            string databaseName = dbName;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string connectionString = "Data Source=" + desktopPath + "\\Databases" + "\\" + databaseName + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            if (File.Exists(desktopPath + "\\Databases" + "\\" + databaseName))
            {
                string newDatabaseName = newDbName;
                string newConnectionString = "Data Source=" + desktopPath + "\\Databases" + "\\" + newDatabaseName + ".db;Version=3;";
                SQLiteConnection newConnection = new SQLiteConnection(newConnectionString);
                newConnection.Open();

                // table names in databases
                string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name<>'sqlite_sequence'";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                // table create 
                while (reader.Read())
                {
                    string tableName = reader["name"].ToString();
                    //PRAGMA =  Table structure 
                    sql = "PRAGMA table_info(" + tableName + ")";
                    command = new SQLiteCommand(sql, connection);
                    SQLiteDataReader tableReader = command.ExecuteReader();
                    // List for table structure.
                    List<string> columns = new List<string>();
                    // Create table for database
                    sql = "CREATE TABLE " + tableName + "(";
                    while (tableReader.Read())
                    {
                        //name, type and primeryKey values for each table
                        string columnName = tableReader["name"].ToString();
                        string columnType = tableReader["type"].ToString();
                        bool columnPK = Convert.ToBoolean(tableReader["pk"]);
                        // adding columns names
                        columns.Add(columnName);
                        // Added columns informations to SQL
                        sql += columnName + " " + columnType;
                        if (columnPK)
                        {
                            sql += " PRIMARY KEY";
                        }
                        sql += ",";
                    }

                    sql = sql.TrimEnd(',') + ")"; //Finish sql
                    SQLiteCommand newCommand = new SQLiteCommand(sql, newConnection);
                    newCommand.ExecuteNonQuery();
                    sql = "SELECT * FROM " + tableName;
                    command = new SQLiteCommand(sql, connection);
                    tableReader = command.ExecuteReader();
                    //New sql euery for any value
                    sql = "INSERT INTO " + tableName + "(" + string.Join(",", columns) + ") VALUES (";
                    foreach (string column in columns)
                    {
                        sql += "@" + column + ",";
                    }
                    sql = sql.TrimEnd(',') + ")";
                    newCommand = new SQLiteCommand(sql, newConnection);
                    while (tableReader.Read()) //reading for result
                    {
                        foreach (string column in columns)
                        {
                            newCommand.Parameters.AddWithValue("@" + column, tableReader[column]);
                        }
                        newCommand.ExecuteNonQuery();
                        newCommand.Parameters.Clear();
                    }
                }
                connection.Close();
                newConnection.Close();
                return true;
            }
            else
            {
                -
                return false;
            }
        }


        public static void CopyTable(string dbName, string newDbName, string tableName)
        {
            // Veritabanı ve tablo isimlerini alıyoruz
            string db1 = dbName;
            string db2 = newDbName;


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            SQLiteConnection connection = new SQLiteConnection("Data Source=" + desktopPath + "\\Databases" + "\\" + db1 + ";Version=3;");
            connection.Open();
            SQLiteConnection newConnection = new SQLiteConnection("Data Source=" + desktopPath + "\\Databases" + "\\" + db2 + ".db" + ";Version=3;");
            newConnection.Open();

            string sql = "PRAGMA table_info(" + tableName + ")";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader tableReader = command.ExecuteReader();

            sql = "CREATE TABLE " + tableName + "(";

            List<string> columns = new List<string>();

            while (tableReader.Read())
            {
                string columnName = tableReader["name"].ToString();
                columns.Add(columnName);

                string columnType = tableReader["type"].ToString();
                bool columnPK = Convert.ToBoolean(tableReader["pk"]);
                sql += columnName + " " + columnType;
                if (columnPK)
                {
                    sql += " PRIMARY KEY";
                }
                sql += ",";
            }

            sql = sql.TrimEnd(',') + ")";

            SQLiteCommand newCommand = new SQLiteCommand(sql, newConnection);
            newCommand.ExecuteNonQuery();

            sql = "SELECT * FROM " + tableName;
            command = new SQLiteCommand(sql, connection);
            tableReader = command.ExecuteReader();

            sql = "INSERT INTO " + tableName + "(" + string.Join(",", columns) + ") VALUES (";
            foreach (string column in columns)
            {
                sql += "@" + column + ",";
            }

            sql = sql.TrimEnd(',') + ")";
            newCommand = new SQLiteCommand(sql, newConnection);

            while (tableReader.Read())
            {
                foreach (string column in columns)
                {
                    newCommand.Parameters.AddWithValue("@" + column, tableReader[column]);
                }
                newCommand.ExecuteNonQuery();
                newCommand.Parameters.Clear();
            }

            connection.Close();
            newConnection.Close();

        }


        public static string[] GetTableForList(string dataBaseName)
        {

            string db1 = dataBaseName;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + desktopPath + "\\Databases" + "\\" + db1 + ".db;Version=3;");
            connection.Open();

            // Get table names in database
            string sql = "SELECT name FROM sqlite_master WHERE type='table'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader tableReader = command.ExecuteReader();


            List<string> tableNames = new List<string>();
            while (tableReader.Read())
            {
                tableNames.Add(tableReader["name"].ToString());
            }
            string[] tableArray = new string[tableNames.Count];

            for (int i = 0; i < tableNames.Count; i++)
            {
                tableArray[i] = tableNames[i];
            }

            return tableArray;
        }

        public static void ListDataForNewStates(DataGrid dataGrid, string dataBaseName)
        {
            string[] libraryDataNames = new string[GetTableForList(dataBaseName).Length];

            for (int i = 0; i < GetTableForList(dataBaseName).Length; i++)
            {
                libraryDataNames[i] = GetTableForList(dataBaseName)[i];
            }

            MessageBox.Show(GetTableForList(dataBaseName).Length.ToString());


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string connectionString = "Data Source=" + desktopPath + "\\Databases" + "\\" + dataBaseName + ".db;Version=3;";
            ObservableCollection<Library> libraries = new ObservableCollection<Library>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < libraryDataNames.Length; i++)
                {
                    if (libraryDataNames[i] != "sqlite_sequence")
                    {
                        string query = "SELECT * FROM " + libraryDataNames[i];
                        SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
                        SQLiteDataAdapter adaptor = new SQLiteDataAdapter(sQLiteCommand);
                        DataTable dataTable = new DataTable(libraryDataNames[i]);
                        adaptor.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // If some values are contained, then if statement returns true
                            if (dataTable.Columns.Contains("productName") && dataTable.Columns.Contains("price") && dataTable.Columns.Contains("color"))
                            {
                                //Adding Library Data for products
                                libraries.Add(new Library { ProductName = row["productName"].ToString(), Price = row["price"].ToString(), Color = row["color"].ToString() });
                            }

                        }
                    }

                }
                dataGrid.ItemsSource = libraries;
            }

        }

        public static void GetTables(string databaseBame, ComboBox comboBox)
        {
            string db1 = databaseBame;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + desktopPath + "\\Databases" + "\\" + db1 + ";Version=3;");
            connection.Open();

            string sql = "SELECT name FROM sqlite_master WHERE type='table'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader tableReader = command.ExecuteReader();

            List<string> tableNames = new List<string>();
            while (tableReader.Read())
            {
                tableNames.Add(tableReader["name"].ToString());
            }

            tableNames.Add("All");
            //Get adata with Combobox items source
            comboBox.ItemsSource = tableNames;

            connection.Close();

        }



        public static void CopySelectedRows(DataGrid dataGrid, string dbName, string newDbName, string tableName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string connectionString = "Data Source=" + desktopPath + "\\Databases" + "\\" + dbName + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            string newConnectionString = "Data Source=" + desktopPath + "\\Databases" + "\\" + newDbName + ";Version=3;";
            SQLiteConnection newConnection = new SQLiteConnection(newConnectionString);
            newConnection.Open();

            // Define a data for library
            ObservableCollection<Library> data = new ObservableCollection<Library>();

            // Datagriddeki verileri Veriler koleksiyonuna aktarma
            foreach (Library item in dataGrid.ItemsSource)
            {
                //Adding item to data for selection
                data.Add(item);
            }

            //Find checked data in data
            var selectedRows = data.Where(x => x.Checkbox == true);

            MessageBox.Show(selectedRows.ToList().Count + "selected rows");

            // Copy selected data to new database
            foreach (var row in selectedRows)
            {
                string sql = "INSERT INTO " + tableName + "(Color, ProductName, Price) VALUES (@Color, @ProductName, @Price)";
                SQLiteCommand command = new SQLiteCommand(sql, newConnection);
                //command.Parameters.AddWithValue("@Character", row.Character);
                //command.Parameters.AddWithValue("@BgColor", row.BgColor.ToString());
                command.Parameters.AddWithValue("@Color", row.Color);
                command.Parameters.AddWithValue("@ProductName", row.ProductName);
                command.Parameters.AddWithValue("@Price", row.Price);
                // command.Parameters.AddWithValue("@Email", row.Email);

                command.ExecuteNonQuery();
            }

            connection.Close();
            newConnection.Close();
        }



    }
}


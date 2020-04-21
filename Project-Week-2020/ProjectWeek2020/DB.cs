using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ProjectWeek2020
{
    class DB
    {
        class DBconnect //informatie gehaald uit https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        {
            private MySqlConnection connection;
            private string Server;
            private string databasesql;
            private string uid;

            public DBconnect()
            {
                DataBase();
                OpenConnection();
                CloseConnection();
            }
            private void DataBase()
            {
                Server = "localhost";
                databasesql = "nursing_home1";
                uid = "root";
                string connectionString;
                connectionString = "Server=" + Server + ";" + "Database= " + databasesql + ";" + "uid= " + uid + ";";
                connection = new MySqlConnection(connectionString);
            }

            private bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            Console.WriteLine("Cannot connect to the database"); //hier messagebox doen.
                            break;

                        case 1045:
                            Console.WriteLine("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }
            private bool CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return false;
                }
            }

            public void Insert()
            {
                string query = "INSERT INTO...";
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            public void Update()
            {
                string query = "Update ....";
                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            public void Delete()
            {
                string query = "DELETE FROM ...";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

        }
    }
}

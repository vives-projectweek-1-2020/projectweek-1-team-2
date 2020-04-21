using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Project_Week_2020
{
    class DB
    {
        public class DBconnect //informatie gehaald uit https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        {
            private MySqlConnection connection;
            private string Server;
            private string databasesql;
            private string uid;
            private string password;

            public DBconnect()
            {
                DataBase();
                Insert();

            }
            private void DataBase()
            {
                Server = "projectweek1.ddns.net";
                databasesql = "nursing_home1";
                uid = "projectweek";
                password = "olifant_watermeloen_balpen_vijventwintig";
                string connectionString;
                connectionString = "Server=" + Server + ";" + "Database= " + databasesql + ";" + "uid= " + uid + ";" + "Password=" + password + ";" ;
                connection = new MySqlConnection(connectionString);
            }

            public bool OpenConnection()
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
            public bool CloseConnection()
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
                //string query = "INSERT INTO people (name, last_name, email, type, temperature, access, access_code) VALUES('Seppe', 'DE_Witte', 'Seppe.Dewitt@gmail.com' ,'visitor', 38, False, 123456);";
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

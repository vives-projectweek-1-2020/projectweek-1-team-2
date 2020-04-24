using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;



namespace Project_Week_2020
{
    public class DB
    {
        public class DBconnect //informatie gehaald uit https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        {
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataReader dataReader;

            private string Server;
            private string databasesql;
            private string uid;
            private string password;
            public bool LOGINVALID = false;
            public bool EMAILVALID = false;
            public bool CheckValid = false;
            public bool TEMPJA = false;
            public string Output;
            public string MakeAPP;
            public string outputvisitor;
            public string userid;
            public string userTemp;
            public string userTempVisitor = "";
            public int NumberDegree = 0;
            public int AccessCode1 = 1;
            public int AccessCode0 = 0;
            public bool FOUNDID = false;




            public DBconnect()
            {
                DataBase();
                RandomNumber();

            }
            public void RandomNumber() //generates a random number.
            {
                Random gen = new Random();
                NumberDegree = gen.Next(34, 41);
            }

            private void DataBase()
            {
                Server = "projectweek1.ddns.net";
                databasesql = "nursing_home1";
                uid = "projectweek1";
                password = System.IO.File.ReadAllText(@"C:\database password\password.txt");
                string connectionString;
                connectionString = "Server=" + Server + ";" + "Database= " + databasesql + ";" + "uid= " + uid + ";" + "Password=" + password + ";";
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
                    ex.ToString();
                    return false;
                }
            }

            public void Insert(string firstname, string lastname, string email, string type, int temperature, bool access, int accesscode)
            {
                //hier if statement plaatsen met valid responce van de DB
                string query = $"INSERT INTO people (name, last_name, email, type, temperature, access, access_code) VALUES('{firstname}', '{lastname}', '{email}' ,'{type}', {temperature.ToString()}, {access.ToString()}, {accesscode});";
                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            public void LoginCheckVisitor(string firstname, string lastname, int accesscode)
            {

                if (this.OpenConnection() == true)
                {
                    string query = $"select id, name, last_name, access_code, access, temperature, type from people where name = '{firstname}' AND last_name = '{lastname}' AND access_code = '{accesscode}' AND type='visitor';";
                    command = new MySqlCommand(query, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {

                        Output = Output + dataReader.GetValue(0);
                        this.userTempVisitor += dataReader.GetValue(5); //hier krijgen we temperature

                    }
                    if (dataReader.HasRows)
                    {
                        LOGINVALID = true;
                        CheckValid = true;
                    }
                    else
                    {
                        LOGINVALID = false;
                    }
                }
            }



            public void LoginCheckPatient(string firstname, string lastname, int accesscode)
            {

                if (this.OpenConnection() == true)
                {
                    string query = $"select id, name, last_name, access_code, access, temperature, type from people where name = '{firstname}' AND last_name = '{lastname}' AND access_code = '{accesscode}' AND type='resident';";


                    command = new MySqlCommand(query, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Output = Output + dataReader.GetValue(0);
                        this.userTemp += dataReader.GetValue(5); //hier krijgen we temperature


                    }
                    if (dataReader.HasRows)
                    {
                        LOGINVALID = true;
                    }
                    else
                    {
                        LOGINVALID = false;
                    }


                }
            }



            public int UpdateTemperature()
            {

                string query = $"update people set temperature = {NumberDegree} where id = {Output};";

                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();


                }
                return NumberDegree;
            }
            public int AccessCorrect()
            {
                string query = $"update people set access = 1 where id  = {Output}";

                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    


                }
                return AccessCode1;

            }
            public int AccessWrong()
            {
                string query = $"update people set access = 0 where id  = {Output}";

                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();


                }
                return AccessCode0;
            }
            public void MakeAppointmentSearch(string firstname, string lastname)
            {
                if (OpenConnection() == true)
                {
                    string query = $"select id, name, last_name from people where name = '{firstname}' and last_name = '{lastname}' and  type = 'resident';";
                    command = new MySqlCommand(query, connection);

                    dataReader = command.ExecuteReader();


                    while (dataReader.Read())
                    {
                        MakeAPP = MakeAPP + dataReader.GetValue(0);
                        
                    }
                    if (dataReader.HasRows)
                    {
                        FOUNDID = true;
                    }
                    else
                    {
                        FOUNDID = false;
                    }
                    CloseConnection();
                }
            }

            public void MakeAppointment()
            {
                if (OpenConnection() == true)
                {
                    string query = $"insert into visits (visitor_id, resident_id) values ({Output} , {MakeAPP});";


                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();

                }
            }

            public void EmailChecker(string email)
            {


                if (OpenConnection() == true)
                {
                    string query = $"select email from people where email = '{email}';";
                    command = new MySqlCommand(query, connection);

                    dataReader = command.ExecuteReader();


                    while (dataReader.Read())
                    {
                        Output = Output + dataReader.GetValue(0);

                    }
                    if (dataReader.HasRows)
                    {
                        EMAILVALID = true;
                    }
                    else
                    {
                        EMAILVALID = false;
                    }
                    CloseConnection();
                }

            }


            public void VISITORCOUNT()
            {
                if (this.OpenConnection() == true)
                {
                    string query = $"select count(id) from people where type= 'Visitor';";


                    command = new MySqlCommand(query, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        outputvisitor = outputvisitor + dataReader.GetValue(0);

                    }


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

            public string History()
            {
                string Visit = "";
                if (this.OpenConnection() == true)
                {

                    string query = $"select concat(people.name, ' ', people.last_name) as name, visits.date_visit from people join visits on people.id = visits.visitor_id where visits.resident_id = {Output} order by date_visit desc;";
                    
                    command = new MySqlCommand(query, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Visit += $"{dataReader.GetValue(0)} --- {dataReader.GetValue(1)}  \n";
                        Console.WriteLine(Output);
                    }

                }
                return Visit;




            }
        }
    }

}
            


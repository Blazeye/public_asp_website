using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
using MySql.Data.MySqlClient;
using log4net;


namespace SKU.CRUD
{
    public class Crud
    {
        private static ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MySqlConnection connection;
        private string Server { get; }
        private string Database { get; }
        private string Username { get; }
        private string Password { get; }

        public Crud(string server, string database, string username, string password)
        {
            LOG.Info("Crud created");
            Server = server;
            Database = database;
            Username = username;
            Password = password;

            Initialize();
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
            Database + ";" + "username=" + Username + ";" + "PASSWORD=" + Password + ";SslMode=none;";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                LOG.Info("Opened database connection");
                return true;
            }
            catch (MySqlException e)
            {
                /* JH: Throw an own exception for example new SkuException(SkuException.NO_DB) */
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                LOG.Warn(e.Message);
                switch (e.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
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
                LOG.Info("Closed database connection");
                return true;
            }
            catch (MySqlException e)
            {
                LOG.Warn(e.Message);
                return false;
            }
        }

        /// <summary>
        /// perform a NonQuery (a query that does not return selected data); insert, update, delete
        /// </summary>
        /// <param>query string</param>
        /// <returns>lastinsertedId on success insert,  or false if not successfull</returns>
        public long NonQuery(string query)
        {
            try
            {
                if (OpenConnection() == true)
                {
                    if (query.StartsWith("delete") && (!query.Contains("where")))
                    {
                        LOG.Info("delete query without where clausule");
                        return 0;
                    }
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    CloseConnection();
                    if (query.StartsWith("insert", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return cmd.LastInsertedId;
                    }
                    else if (rowsAffected < 1)
                    {
                        LOG.Info("query was not succesfull.");
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (MySqlException e)
            {
                LOG.Info(e.Message);
                return 0;
            }
            return 0;
        }

        //gebruik (inner/outer) zie netbeans join voor category en onderwerpen query in 1 query
        /// <summary>
        /// perform a select query
        /// </summary>
        /// <param>query string</param>
        /// <returns>List of dictionaries that contains the found results (or empty)  or null if not succesfull </returns>
        public List<Dictionary<string, string>> SelectQuery(string query)
        {
            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();

            if (OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Dictionary<string, string> rowDictionary = new Dictionary<string, string>(dataReader.FieldCount);
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            if (dataReader.IsDBNull(i)) {
                                rowDictionary.Add(dataReader.GetName(i), null);
                            } else {
                                rowDictionary.Add(dataReader.GetName(i), dataReader.GetString(i));
                            }
                        }
                        resultList.Add(rowDictionary);
                    }
                    dataReader.Close();
                    this.CloseConnection();
                    return resultList;
                }
                catch (MySqlException e)
                {
                    LOG.Warn(e.Message);
                    this.CloseConnection();
                    throw;
                }
            }
            LOG.Error("no connection was established");
            return null;
        }
    }
}

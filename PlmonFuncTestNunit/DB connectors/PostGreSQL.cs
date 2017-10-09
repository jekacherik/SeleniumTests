using AventStack.ExtentReports;
using Npgsql;
using NUnit.Framework;
using PlmonFuncTestNunit.Base_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.DB_connectors
{
    public  class PostGreSQL
    {
        List<string> dataItems = new List<string>();
        protected TestsConfiguration _conf = null;
        protected PostGreSQL _pG;

        public void PostgreSQL()
        {
            
        }
        public void InitConf()
        {
            _conf = TestsConfiguration.Instance;
        }

        public List<string> PostgreSQLtest1()
        {
            try
            {
                _conf = TestsConfiguration.Instance;
                string connstring = _conf.Connstring;
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM login", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(/*dataReader[0].ToString() + "," +*/ dataReader[1].ToString() + "," + dataReader[2].ToString() + "\r\n");
                    PropertiesCollection._reportingTasks.Log(Status.Info, "<b>"+"This data from DB Postgres "+"</b>" + dataItems[i]);
                }
                connection.Close();
                return dataItems;

            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
                PropertiesCollection._reportingTasks.Log(Status.Error, msg.ToString());
                throw;
            }
        }
        public void PostgreTestInsert()
        {
            _conf = TestsConfiguration.Instance;
            try
            {
                string connstring = _conf.Connstring;
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                FileInfo file = new FileInfo(@"C:\VS projects\PlmonFuncTestNunit\PlmonFuncTestNunit\DB connectors\InsertLoginTable.sql");
                string script = file.OpenText().ReadToEnd();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(script, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception msg1)
            {
                Console.WriteLine(msg1.ToString());
                PropertiesCollection._reportingTasks.Log(Status.Error, msg1.ToString());
                throw;
            }

        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;


namespace NewSQLScheduler
{
    class Util
    {

        //loga em arquivo de texto
        public static void logInFile(string text, string T)
        {


         string path = (AppDomain.CurrentDomain.BaseDirectory) + "\\Log\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + T + ".log";
            

            string data = System.DateTime.Now.ToString();
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    file.WriteLine(data + " - " + text);
            }
            catch
            {
                return;
            }

        }


        public static int executeSQL(string sqlCommand, string selectDatabase, string dataSource, string user, string password)
        {
            string useDataBase = string.Empty;
            if (!selectDatabase.Equals(string.Empty))
                useDataBase = "use [" + selectDatabase + "]";

            try
            {
                using (SqlConnection _con = new SqlConnection("Data Source=" + dataSource + ";User ID=" + user + "; Password=" + password + "; Connect Timeout=1200"))
                {
                    _con.Open();

                    if (!useDataBase.Equals(string.Empty))
                    {
                        SqlCommand database = new SqlCommand(useDataBase, _con);
                        database.ExecuteNonQuery();
                    }

                    SqlCommand cmd = new SqlCommand(sqlCommand, _con);
                    cmd.CommandTimeout = 1200;
                    cmd.ExecuteNonQuery();

                    _con.Close();
                }
               
            }

            catch (Exception e)
            {
                Util.logInFile(e.Message, "ERROR");
            }

            return 0;
        }


    }
}

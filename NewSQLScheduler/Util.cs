using System;
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
        public static void logInFile(string text, string path)
        {

            if (path == null)
            {
                path = (AppDomain.CurrentDomain.BaseDirectory) + DateTime.Now.ToString("YYYYMMDD") + ".log";
            }

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



        //le os arquivos .sql
        public static string readSqlFile(string path)
        {
            string ret = string.Empty;

            try
            {
                using (System.IO.StreamReader Sqlfile = new System.IO.StreamReader(path))
                    ret = Sqlfile.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }

            return ret;
        }



        public static int executeSQL(string sqlCommand, string selectDatabase, string dataSource, string user, string password)
        {
            string useDataBase = string.Empty;
            if (!selectDatabase.Equals(string.Empty))
                useDataBase = "use [" + selectDatabase + "]";

            try
            {
                SqlConnection _con = new SqlConnection("Data Source=" + dataSource + ";User ID=" + user + "; Password=" + password + "; Connect Timeout=60");
                _con.Open();

                if (!useDataBase.Equals(string.Empty))
                {
                    SqlCommand database = new SqlCommand(useDataBase, _con);
                    database.ExecuteNonQuery();
                }

                SqlCommand cmd = new SqlCommand(sqlCommand, _con);
                cmd.ExecuteNonQuery();

                _con.Close();
            }

            catch (Exception e)
            {
                return 1;
            }

            return 0;
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSQLScheduler
{
    class Configurations
    {

        public static string USER;
        public static string PASS;
        public static string SERVER;
        public static string DATABASE;
        public static int TIMETICK_T1;
        public static int TIMETICK_T2;
        public static int TIMETICK_T3;
        public static int TIMETICK_T4;
        public static int TIMETICK_T5;
        public static int TIMETICK_T6;
        public static int TIMETICK_T7;
        public static int TIMETICK_T8;
        public static int TIMETICK_T9;
        public static int TIMETICK_T10;

        public static void readConfigurations()
        {

            string sTIMETICK_T1 = "0";
            string sTIMETICK_T2 = "0";
            string sTIMETICK_T3 = "0";
            string sTIMETICK_T4 = "0";
            string sTIMETICK_T5 = "0";
            string sTIMETICK_T6 = "0";
            string sTIMETICK_T7 = "0";
            string sTIMETICK_T8 = "0";
            string sTIMETICK_T9 = "0";
            string sTIMETICK_T10 = "0";

            string line;
            string[] fields;

            try
            {
                using (System.IO.StreamReader inputFile = new StreamReader(new FileStream(AppDomain.CurrentDomain.BaseDirectory + "//Config.ini", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        fields = line.Split('=');

                        if (fields.Length > 0)
                        {

                            switch (fields[0])
                            {

                                case "USER":
                                    USER = fields[1];
                                    break;

                                case "PASS":
                                    PASS = fields[1];
                                    break;

                                case "SERVER":
                                    SERVER = fields[1];
                                    break;

                                case "DATABASE":
                                    DATABASE = fields[1];
                                    break;

                                case "TIMETICK_T1":
                                    sTIMETICK_T1 = fields[1];
                                    break;

                                case "TIMETICK_T2":
                                    sTIMETICK_T2 = fields[1];
                                    break;

                                case "TIMETICK_T3":
                                    sTIMETICK_T3 = fields[1];
                                    break;
                                case "TIMETICK_T4":
                                    sTIMETICK_T4 = fields[1];
                                    break;

                                case "TIMETICK_T5":
                                    sTIMETICK_T5 = fields[1];
                                    break;

                                case "TIMETICK_T6":
                                    sTIMETICK_T6 = fields[1];
                                    break;

                                case "TIMETICK_T7":
                                    sTIMETICK_T7 = fields[1];
                                    break;

                                case "TIMETICK_T8":
                                    sTIMETICK_T8 = fields[1];
                                    break;

                                case "TIMETICK_T9":
                                    sTIMETICK_T9 = fields[1];
                                    break;

                                case "TIMETICK_T10":
                                    sTIMETICK_T10 = fields[1];
                                    break;

                            }
                        }

                    }
                }


                int.TryParse(sTIMETICK_T1, out TIMETICK_T1);
                int.TryParse(sTIMETICK_T2, out TIMETICK_T2);
                int.TryParse(sTIMETICK_T3, out TIMETICK_T3);
                int.TryParse(sTIMETICK_T4, out TIMETICK_T4);
                int.TryParse(sTIMETICK_T5, out TIMETICK_T5);
                int.TryParse(sTIMETICK_T6, out TIMETICK_T6);
                int.TryParse(sTIMETICK_T7, out TIMETICK_T7);
                int.TryParse(sTIMETICK_T8, out TIMETICK_T8);
                int.TryParse(sTIMETICK_T9, out TIMETICK_T9);
                int.TryParse(sTIMETICK_T10, out TIMETICK_T10);




            }
            catch (Exception e)
            {
                Util.logInFile("------------------> Erro ao ler o arquivo de configuração." + e.Message.ToString(), "Error");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace NewSQLScheduler
{
    public partial class NewSQLScheduler : ServiceBase
    {

        static Timer timer1;
        static Timer timer2;
        static Timer timer3;
        static Timer timer4;
        static Timer timer5;
        static Timer timer6;
        static Timer timer7;
        static Timer timer8;
        static Timer timer9;
        static Timer timer10;

        public NewSQLScheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Util.logInFile("*** PlantSuite New SQL Scheduler for SQL Express 15-12-2020 -> by MMJR ***", "Info");
            Thread.Sleep(1000);
            Util.logInFile("--> Lendo arquivo de configuração", "Info");

            //le arquivo de configuração
            Configurations.readConfigurations();

            if (Configurations.TIMETICK_T1 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer1_Tick), null, 5000, Configurations.TIMETICK_T1);
            else
                Util.logInFile("Falha de inicialização T1", "Info");

            if (Configurations.TIMETICK_T2 > 1000) //trava em pelo menos 1 segundo
                timer2 = new Timer(new TimerCallback(timer2_Tick), null, 6000, Configurations.TIMETICK_T2);
            else
                Util.logInFile("Falha de inicialização T2", "Info");

            if (Configurations.TIMETICK_T3 > 1000) //trava em pelo menos 1 segundo
                timer3 = new Timer(new TimerCallback(timer3_Tick), null, 7000, Configurations.TIMETICK_T3);
            else
                Util.logInFile("Falha de inicialização T3", "Info");

            if (Configurations.TIMETICK_T4 > 1000) //trava em pelo menos 1 segundo
                timer4 = new Timer(new TimerCallback(timer4_Tick), null, 8000, Configurations.TIMETICK_T4);
            else
                Util.logInFile("Falha de inicialização T4", "Info");

            if (Configurations.TIMETICK_T5 > 1000) //trava em pelo menos 1 segundo
                timer5 = new Timer(new TimerCallback(timer5_Tick), null, 9000, Configurations.TIMETICK_T5);
            else
                Util.logInFile("Falha de inicialização T5", "Info");

            if (Configurations.TIMETICK_T6 > 1000) //trava em pelo menos 1 segundo
                timer6 = new Timer(new TimerCallback(timer6_Tick), null, 10000, Configurations.TIMETICK_T6);
            else
                Util.logInFile("Falha de inicialização T6", "Info");

            if (Configurations.TIMETICK_T7 > 1000) //trava em pelo menos 1 segundo
                timer7 = new Timer(new TimerCallback(timer7_Tick), null, 11000, Configurations.TIMETICK_T7);
            else
                Util.logInFile("Falha de inicialização T7", "Info");

            if (Configurations.TIMETICK_T8 > 1000) //trava em pelo menos 1 segundo
                timer8 = new Timer(new TimerCallback(timer8_Tick), null, 12000, Configurations.TIMETICK_T8);
            else
                Util.logInFile("Falha de inicialização T8", "Info");

            if (Configurations.TIMETICK_T9 > 1000) //trava em pelo menos 1 segundo
                timer9 = new Timer(new TimerCallback(timer9_Tick), null, 13000, Configurations.TIMETICK_T9);
            else
                Util.logInFile("Falha de inicialização T9", "Info");

            if (Configurations.TIMETICK_T10 > 1000) //trava em pelo menos 1 segundo
                timer10 = new Timer(new TimerCallback(timer10_Tick), null, 14000, Configurations.TIMETICK_T10);
            else
                Util.logInFile("Falha de inicialização T10", "Info");

            Util.logInFile("Sistema Iniciado...", "Info");

        }

        protected override void OnStop()
        {
        }

        private void timer1_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T1]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);
                st.Stop();

                Util.logInFile("T1 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T1");
            }
            catch
            {
                Util.logInFile("ERRO T1", "T1");
            }

        }

        private void timer2_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T2]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T2 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T2");
            }
            catch
            {
                Util.logInFile("ERRO T2", "T2");
            }

        }


        private void timer3_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T3]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T3 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T3");
            }
            catch
            {
                Util.logInFile("ERRO T3", "T3");
            }

        }


        private void timer4_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T4]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T4 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T4");
            }
            catch
            {
                Util.logInFile("ERRO T4", "T4");
            }

        }


        private void timer5_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T5]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T5 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T5");
            }
            catch
            {
                Util.logInFile("ERRO T5", "T5");
            }

        }


        private void timer6_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T6]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T6 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T6");
            }
            catch
            {
                Util.logInFile("ERRO T6", "T6");
            }

        }


        private void timer7_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T7]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T7 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T7");
            }
            catch
            {
                Util.logInFile("ERRO T7", "T7");
            }

        }


        private void timer8_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T8]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T8 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T8");
            }
            catch
            {
                Util.logInFile("ERRO T8", "T8");
            }

        }


        private void timer9_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T9]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T9 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T9");
            }
            catch
            {
                Util.logInFile("ERRO T9", "T9");
            }

        }


        private void timer10_Tick(object sender)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();

                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T10]", Configurations.DATABASE, Configurations.SERVER, Configurations.USER, Configurations.PASS);

                st.Stop();
                Util.logInFile("T10 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T10");
            }
            catch
            {
                Util.logInFile("ERRO T10", "T10");
            }

        }


    }
}

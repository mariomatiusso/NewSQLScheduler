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

        Timer timer1;
        Timer timer2;
        Timer timer3;
        Timer timer4;
        Timer timer5;
        Timer timer6;

        public NewSQLScheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Util.logInFile("*** PlantSuite New SQL Scheduler for SQL Express 21-10-2020 -> by MMJR ***", "Info");
            Thread.Sleep(1000);
            Util.logInFile("--> Lendo arquivo de configuração", "Info");

            //le arquivo de configuração
            Configurations.readConfigurations();

            if (Configurations.TIMETICK_T1 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer1_Tick), null, 5000, Configurations.TIMETICK_T1);

            if (Configurations.TIMETICK_T2 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer2_Tick), null, 5000, Configurations.TIMETICK_T2);

            if (Configurations.TIMETICK_T3 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer3_Tick), null, 5000, Configurations.TIMETICK_T3);

            if (Configurations.TIMETICK_T4 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer4_Tick), null, 5000, Configurations.TIMETICK_T4);

            if (Configurations.TIMETICK_T5 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer5_Tick), null, 5000, Configurations.TIMETICK_T5);

            if (Configurations.TIMETICK_T6 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer6_Tick), null, 5000, Configurations.TIMETICK_T6);

            if (Configurations.TIMETICK_T7 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer7_Tick), null, 5000, Configurations.TIMETICK_T7);

            if (Configurations.TIMETICK_T8 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer8_Tick), null, 5000, Configurations.TIMETICK_T8);

            if (Configurations.TIMETICK_T9 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer9_Tick), null, 5000, Configurations.TIMETICK_T9);

            if (Configurations.TIMETICK_T10 > 1000) //trava em pelo menos 1 segundo
                timer1 = new Timer(new TimerCallback(timer10_Tick), null, 5000, Configurations.TIMETICK_T10);


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
                Util.logInFile("T6 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T6");
            }
            catch
            {
                Util.logInFile("ERRO T6", "T6");
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
                Util.logInFile("T6 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T6");
            }
            catch
            {
                Util.logInFile("ERRO T6", "T6");
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
                Util.logInFile("T6 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T6");
            }
            catch
            {
                Util.logInFile("ERRO T6", "T6");
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
                Util.logInFile("T6 executado. Tempo decorrido:" + st.ElapsedMilliseconds.ToString() + " ms", "T6");
            }
            catch
            {
                Util.logInFile("ERRO T6", "T6");
            }

        }


    }
}

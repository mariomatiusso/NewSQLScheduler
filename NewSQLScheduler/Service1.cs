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
            //timer1 = new Timer(new TimerCallback(timer1_Tick), null, 5000, 1000);
            //timer2 = new Timer(new TimerCallback(timer2_Tick), null, 5000, 5000);
            timer3 = new Timer(new TimerCallback(timer3_Tick), null, 5000, 10000);
            timer4 = new Timer(new TimerCallback(timer4_Tick), null, 5500, 60000);
            timer5 = new Timer(new TimerCallback(timer5_Tick), null, 6000, 600000);
            timer6 = new Timer(new TimerCallback(timer5_Tick), null, 6500, 1200000);

        }

        protected override void OnStop()
        {
        }


        private void timer1_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T1", "T1");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T1]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T1", "T1");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T1", "T1");
            }

        }

        private void timer2_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T2", "T2");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T2]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T2", "T2");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T2", "T2");
            }

        }


        private void timer3_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T3", "T3");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T3]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T3", "T3");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T3", "T3");
            }

        }


        private void timer4_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T4", "T4");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T4]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T4", "T4");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T4", "T4");
            }

        }


        private void timer5_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T5", "T5");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T5]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T5", "T5");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T5", "T5");
            }

        }


        private void timer6_Tick(object sender)
        {
            try
            {
                Util.logInFile("Execuntado T6", "T6");
                Util.executeSQL("exec [PSServerCustom].[dbo].[USP_T6]", "PSServerCustom", "Localhost", "ps_server", "@PS$Adm");
                Util.logInFile("Finalizando T6", "T6");
            }
            catch
            {
                Util.logInFile("*************************************** ERRO T6", "T6");
            }

        }


    }
}

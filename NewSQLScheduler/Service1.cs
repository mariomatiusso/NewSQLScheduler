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
        Timer timer7;
        Timer timer8;
        Timer timer9;
        Timer timer10;
        Timer timer11;

        public NewSQLScheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(timer1_Tick), null, 1000, 1000);
        }

        protected override void OnStop()
        {
        }


        private void timer1_Tick(object sender)
        {

            Util.logInFile("teste", null);

        }


    }
}

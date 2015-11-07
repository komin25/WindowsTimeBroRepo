using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTrackingCode
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt";
            Library lib = new Library();
            ;

            Process[] processlist = lib.ShowProcesses();

            lib.WriteToFile(processlist, path);
        }

        protected override void OnStop()
        {
        }
    }
}

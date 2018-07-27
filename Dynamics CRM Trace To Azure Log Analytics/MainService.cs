using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics_CRM_Trace_To_Azure_Log_Analytics
{
    partial class MainService : ServiceBase
    {
        public MainService()
        {
        }
        
        public void OnDebug()
        {
            OnStart(null)
;        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            var x = new DirectoryHandler();
            x.Debug();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}

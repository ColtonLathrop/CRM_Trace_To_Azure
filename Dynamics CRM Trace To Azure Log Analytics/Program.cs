using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CrmTraceReader;

namespace Dynamics_CRM_Trace_To_Azure_Log_Analytics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            MainService _service = new MainService();
            _service.OnDebug();
#else


            ServiceBase _service = new MainService();
            ServiceBase.Run(_service);
#endif
        }

        //static void BwLoadFileDoWork()
        //{
        //    var files = new List<string>();
        //    foreach (var file in files)
        //    {
        //        using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        using (var reader = new StreamReader(fileStream))
        //        {
        //            TraceInfo ti = null;
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                if (line.Trim().StartsWith("#") || string.IsNullOrEmpty(line))
        //                    continue;

        //                if (line.StartsWith("["))
        //                {
        //                    var lineParts = line.Split('|');

        //                    if (lineParts.Length == 1)
        //                    {
        //                        ti.Description += lineParts[0];
        //                        continue;
        //                    }

        //                    if (ti != null)
        //                    {
        //                        traces.Add(ti);
        //                    }

        //                    var threadParts = lineParts[2].Split(':');
        //                    var list = threadParts.ToList();
        //                    list.RemoveAt(0);

        //                    ti = new TraceInfo();

        //                    for (int i = 0; i < lineParts.Length; i++)
        //                    {
        //                        if (i == 0)
        //                        {
        //                            var parts = lineParts[i].Split(']');
        //                            ti.Date = DateTime.Parse(parts[0].Remove(0, 1));
        //                            ti.Process = parts[1].Trim().Split(':')[1].Trim();
        //                        }
        //                        else
        //                        {
        //                            if (ti.Process == "OUTLOOK")
        //                            {
        //                                var parts = lineParts[i].Split(':');
        //                                switch (parts[0].Trim())
        //                                {
        //                                    case "Thread":
        //                                        ti.Thread = parts[1].Trim();
        //                                        break;
        //                                    case "Category":
        //                                        ti.Category = parts[1].Trim();
        //                                        break;
        //                                    case "User":
        //                                        ti.User = parts[1].Trim();
        //                                        break;
        //                                    case "Level":
        //                                        ti.Level = parts[1].Trim();
        //                                        break;
        //                                    default:
        //                                        ti.Description = lineParts[i].Trim() + "\r\n";
        //                                        break;
        //                                }

        //                                ti.Organization = string.Empty;
        //                                ti.ReqId = string.Empty;
        //                                ti.Context = string.Empty;
        //                            }
        //                            else
        //                            {
        //                                var parts = lineParts[i].Split(':');
        //                                switch (parts[0].Trim())
        //                                {
        //                                    case "Organization":
        //                                        ti.Organization = parts[1].Trim();
        //                                        break;
        //                                    case "Thread":
        //                                        ti.Thread = parts[1].Trim();
        //                                        break;
        //                                    case "Category":
        //                                        ti.Category = parts[1].Trim();
        //                                        break;
        //                                    case "User":
        //                                        ti.User = parts[1].Trim();
        //                                        break;
        //                                    case "Level":
        //                                        ti.Level = parts[1].Trim();
        //                                        break;
        //                                    case "ReqId":
        //                                        ti.ReqId = parts[1].Trim();
        //                                        break;
        //                                    default:
        //                                        ti.Context = lineParts[i].Trim().Split(' ')[0];
        //                                        break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                else if (line.StartsWith(">"))
        //                {
        //                    ti.Description += line.Remove(0, 1) + "\r\n";
        //                }
        //                else
        //                {
        //                    ti.Description += line + "\r\n";
        //                }
        //            }
        //        }
        //    }

        //    var bw = (BackgroundWorker)sender;

        //    if (oData.Count > 0)
        //    {
        //        bw.ReportProgress(0, "Resolving names...");

        //        foreach (var trace in traces.Where(t => t.Process != "OUTLOOK"))
        //        {
        //            var orgData = oData.FirstOrDefault(o => o.Id == new Guid(trace.Organization));
        //            if (orgData != null)
        //            {
        //                trace.Organization = orgData.Name;

        //                if (new Guid(trace.User) == Guid.Empty)
        //                {
        //                    trace.User = "(none)";
        //                }
        //                else
        //                {
        //                    trace.User = orgData.Users.ContainsKey(new Guid(trace.User)) ? orgData.Users[new Guid(trace.User)] : trace.User;
        //                }
        //            }
        //            else
        //            {
        //                if (new Guid(trace.Organization) == Guid.Empty)
        //                {
        //                    trace.Organization = "(none)";
        //                }

        //                if (new Guid(trace.User) == Guid.Empty)
        //                {
        //                    trace.User = "(none)";
        //                }
        //            }
        //        }
        //    }

        //    bw.ReportProgress(0, "Loading traces...");
        //    e.Result = DisplayTrace(traces, (BackgroundWorker)sender);
        //}
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics_CRM_Trace_To_Azure_Log_Analytics
{
    class DirectoryHandler
    {
        //Temporary Static Variables for POC.
        string _directory = @"C:\Program Files\Microsoft Dynamics CRM\Trace";

        private bool VerifyTraceDirectory(string directory)
        {
            return Directory.Exists(directory);
        }

        private IEnumerable<string> RetrieveFiles(string directory)
        {
            return Directory.GetFiles(directory);
        }

        /// <summary>
        /// Verifies trace directory specified exists, then parses the directory for a string list and converts them to FileInfo Objects.
        /// </summary>
        /// <returns>
        /// List of FileInfo objects in trace directory.
        /// </returns>
        private List<FileInfo> BuildFileObjects(string directory)
        {
            if (VerifyTraceDirectory(directory) != true)
            {
                throw new FileNotFoundException();
            }
            else
            {
                var fileObjects = new List<FileInfo>();
                var fileStrings = RetrieveFiles(directory);
                foreach (string fileName in fileStrings)
                {
                    fileObjects.Add(new FileInfo(fileName));
                }
                return fileObjects;
            }
        }

        /// <summary>
        /// Takes an input list of FileInfo objects and sorts them only keeping the oldest in the list.
        /// </summary>
        /// <returns>
        /// List of 5 FileInfo objects that are the oldest from the input.
        /// </returns>
        private List<FileInfo> SortFiles(List<FileInfo> files)
        {
            List<FileInfo> sorted = new List<FileInfo>(5);
            foreach (var x in files)
            {
                if (sorted.Count < 5)
                {
                    sorted.Add(x);
                    continue;
                }
                var index = -1;
                foreach (var z in sorted.ToList())
                {
                    if (x.LastWriteTimeUtc < z.LastWriteTimeUtc)
                    {
                        index = sorted.IndexOf(z);
                    }
                }
                if (index != -1)
                {
                    sorted[index] = x;
                }
            }
            return sorted;
        }

        /// <summary>
        /// Calls the method to build the FileInfo list then sorts and returns the FileInfo list containing the 5 oldest from the directory.
        /// </summary>
        /// <returns>
        /// List of 5 FileInfo objects that are the oldest from the specified trace directory.
        /// </returns>
        private List<FileInfo> PullFive()
        {
            List<FileInfo> files = BuildFileObjects(_directory);
            var sorted_files = SortFiles(files);
            return sorted_files;
        }

        private byte[] ConvertToBytes(string target)
        {
            return new UTF8Encoding(true).GetBytes(target);
        }

        public void Debug()
        {
            var z = File.Create(@"C:\Users\colathro\source\repos\Dynamics CRM Trace To Azure Log Analytics\Dynamics CRM Trace To Azure Log Analytics\test.txt");
            var x = PullFive();
            foreach (FileInfo test in x)
            {
                byte[] f = ConvertToBytes(test.Name + test.LastWriteTimeUtc.ToString() + Environment.NewLine);
                z.Write(f, 0, f.Length);
            }
        }
    }
}

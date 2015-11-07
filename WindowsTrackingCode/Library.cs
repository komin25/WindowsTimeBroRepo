using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace WindowsTrackingCode
{
    public class Library
    {
        public Process[] ShowProcesses()
        {
            Process[] processlist = Process.GetProcesses();

            return processlist;
        }

        public void WriteToFile(Process[] processlist, string path)
        {
            try
            {

                using (StreamWriter file = new StreamWriter(path, true))
                {

                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }

                    foreach (Process proc in processlist)
                    {
                        try
                        {
                            file.WriteLine("Process Name: {0}, Process ID: {1}, Process StartTime: {2}", proc.ProcessName, proc.Id, proc.StartTime);
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            file.WriteLine("Process Name: {0}, Process ID: {1}", proc.ProcessName, proc.Id);

                            continue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}

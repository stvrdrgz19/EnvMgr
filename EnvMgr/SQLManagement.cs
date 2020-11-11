using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EnvMgr
{
    class SQLManagement
    {
        public static string[] InstalledSQLServers()
        {
            List<string> sqlServerList = new List<string>();
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        sqlServerList.Add(instanceName);
                    }
                }
            }
            return sqlServerList.ToArray();
        }

        public static List<string> GetRunningSQLServers()
        {
            string[] sqlServerList = InstalledSQLServers();
            List<string> runningServers = new List<string>();
            foreach (string server in sqlServerList)
            {
                ServiceController selectedService = new ServiceController("MSSQL$" + server);
                if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                {
                    runningServers.Add(server);
                }
            }
            return runningServers.ToList();
        }
    }
}

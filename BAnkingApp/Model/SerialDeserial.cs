using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace BAnkingApp
{
    public class SerialDeserial
    {
        public static string filePath = ConfigurationManager.AppSettings["filepath"];
        public static void SerializeData(List<Account> accounts)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(accounts));
        }

        public static List<Account> DesrializeData()
        {
            List<Account> accounts = null;
            if (File.Exists(filePath))
            {
                string json= File.ReadAllText(filePath);
                accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            }
            return accounts;

        }

    }
}

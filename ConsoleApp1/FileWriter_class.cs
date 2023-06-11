using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnectionString;
using GetData;
using fileWriter;
using Dapper;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace fileWriter
{
    public class FileWriter
    {

        public static List <SQLGetData> writeToFile(List <SQLGetData>retreiveHATs)
        {
            var helperCall = new SQLGetData();
            List<SQLGetData> retreiveHATs_Helper = helperCall.helperFunction(retreiveHATs);
            String todaysDate = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");

            /* Function to write data to a file on your machine */

            using (StreamWriter writer = File.CreateText("F:\\C# Development\\HAT-Log-Results\\Log.txt"))
            {



                if (retreiveHATs.Any())
                {
                    foreach (SQLGetData m in retreiveHATs_Helper)
                    {
                        writer.WriteLine($"{m.User_Name_f}  {m.User_Name_s}  {m.LogOnDateTime}");
                    }
                }
                else writer.WriteLine($"Since {todaysDate} -> Nobody has logged on");

            }
            return retreiveHATs;
        }

        public static void errorMessages(string message)
        {
            using (StreamWriter writer = File.CreateText("F:\\C# Development\\HAT-Log-Results\\Errors.txt"))
                {
                writer.WriteLine("Error sending email:" + message);
            }
        }
    }   
           
        
    }


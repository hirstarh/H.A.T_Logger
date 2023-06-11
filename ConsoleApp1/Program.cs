using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnectionString;
using GetData;
using Dapper;
using System.Data;
using System.IO;
using fileWriter;
using EmailMessage;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string retrieveData = ConnectionString.GetConnectionString();
            var parameters = new DynamicParameters();
            var dataAccess = new SQLGetData(retrieveData);
            string todaysDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

           parameters.Add("@Date", todaysDate);

            var data = dataAccess.refreshLogger<SQLGetData>("Get_HAT_User", parameters);

                              
           List<SQLGetData> retreiveHATs = dataAccess.hatData<SQLGetData>();

            FileWriter.writeToFile(retreiveHATs);

           

            if (retreiveHATs.Any())
            {
                emailMessage send = new emailMessage();
                send.sendMessage();
            }

            
        }

        
    }
}

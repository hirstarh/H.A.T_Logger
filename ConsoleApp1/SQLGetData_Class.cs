using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SqlConnectionString;
using System.Security.Cryptography.X509Certificates;
using fileWriter;
using System.Runtime.CompilerServices;

namespace GetData
{
    public class SQLGetData 
    {

        private readonly string _connectionString;
        public string User_Name_f { get; set; }
        public string User_Name_s { get; set; }
        public string LogOnDateTime { get; set; }

        public SQLGetData()
        { 
          
        
        } 

        public SQLGetData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SQLGetData( string _User_Name_f, string _User_Name_s, string _LogOnDateTime)
        {
            _User_Name_f = User_Name_f;
            _User_Name_s = User_Name_s;
            _LogOnDateTime = LogOnDateTime;
           
        }

        public IEnumerable<T> refreshLogger<T>(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<T>(storedProcedureName, parameters,commandType: CommandType.StoredProcedure);
            }
        }

        public List<SQLGetData> hatData<SQLGetData>()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string sqlScript = "SELECT * FROM HATMonitor";

                               

                return connection.Query<SQLGetData>(sqlScript).ToList(); 

               


                
            }
        }
        public List<SQLGetData> helperFunction<SQLGetData>(List <SQLGetData>data)
        {
            
            
            return data.ToList();
        }

    }

}

﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionString
{
    public static class ConnectionString 
    {
        public static string GetConnectionString()
        {
             return
             ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;

        }
    }
}

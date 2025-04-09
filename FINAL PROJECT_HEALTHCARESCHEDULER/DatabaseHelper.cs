using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    internal class DatabaseHelper
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo - i5 13th Gen\Documents\Healthcarescheduler.accdb;";

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }
    }
}

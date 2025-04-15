using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public  class BaseClass : UserControl
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo - i5 13th Gen\Documents\Healthcarescheduler.accdb;";
        public string loggedInFirstName { get; set; }
        public string loggedInLastName { get; set; }

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }
    }
}

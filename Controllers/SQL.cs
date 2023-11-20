using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WPF_MySQL.Controllers
{
    public class SQL
    {

       // save the connection object as public
       public MySqlConnection connection;

       // create constructor 
       public SQL()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "Server=localhost;User ID=quiz_user;Password=123456789;Database=questions";
            connection.Open();

        }
        

        

    }
}

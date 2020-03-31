using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HomeService.Models
{
    public class Query
    {
        public String txtName { get; set; }
        public String txtEmail { get; set; }
        public String txtMessage { get; set; }

    
        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=HomeService;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;


        public void QueryRecord(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HomeService.Models
{
    public class Login
    {
        public String txtUserName { get; set;}

        public String txtUserPassword { get; set; }


        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=LAPTOP-NI9FNBTG\\SQLEXPRESS02;Initial Catalog=HomeService;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;


        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();

            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }


    }
}
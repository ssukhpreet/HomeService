using HomeService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login() {

            ViewBag.Message = "Your application description page.";
            return View();

        }


        public ActionResult adminLogin(Login data) {
            String query = "select * from Login where UserName='"+data.txtUserName+"' and UserPassword='"+data.txtUserPassword+"'";
            DataTable tbl = new DataTable();
            tbl = data.srchRecord(query);
            if (tbl.Rows.Count>0) {
                return View("HomePannel");
            }
            else {
                return View("Wrong");
            }

        }
        public ActionResult Thanks()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //ContactMessage
        public ActionResult ContactMessage(Query data)
        {
            String pass = "insert into contact(Name,Email,Message) values ('"+data.txtName+"','"+data.txtEmail+"','"+data.txtMessage+"')";

            data.QueryRecord(pass);
            return View("Thanks");

        }

        public ActionResult Wrong()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult HomePannel()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }




        public ActionResult Services()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServerApp.Models;
using System.Data.SqlClient;

namespace TropicalServerApp.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // static user object 
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString() {
            con.ConnectionString = "Data Source=Wen;Initial Catalog=TropicalServer;Integrated Security=True;";
                }


        [HttpPost]
        public ActionResult Verify(Account account) {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tblUserLogin where UserID='" + account.UserID + "' and Password='" + account.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("../Home/Index");
            }
            else {
                con.Close();
                
                return RedirectToAction("/Login");
            }
        }

        public ActionResult ForgotUserID()
        {
            return View("ForgotUserID");
        }

        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        public ActionResult Logout() {
            return RedirectToAction("/Login");
        }
    }
}
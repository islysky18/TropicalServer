using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServerApp.Models;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;

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

        [HttpPost]
        public ActionResult SendEmail(Account account)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select UserID from tblUserLogin where EmailID='" + account.EmailID + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                var senderEmail = new MailAddress("galaboompow@gmail.com", "galaboompow@gmail.com");
                var receiverEmail = new MailAddress("islysky18@gmail.com", "Receiver");
                var password = "Zzz1234567890!";
                var sub = "Your Login Info";
                var body = "Your Login in password is: " + dr["UserID"];
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password),
                    EnableSsl = true,

                };

                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                con.Close();
                return View("Success");
            }
            else {
                con.Close();
                return View("Error");
                    }
        }
        public ActionResult SendPassWord(Account account)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select UserID from tblUserLogin where EmailID='" + account.EmailID + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                var senderEmail = new MailAddress("galaboompow@gmail.com", "galaboompow@gmail.com");
                var receiverEmail = new MailAddress("islysky18@gmail.com", "Receiver");
                var password = "Zzz1234567890!";
                var sub = "Your Login Info";
                var body = "Your Login in Password is: " + dr["Password"];
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password),
                    EnableSsl = true,

                };

                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                con.Close();
                return View("Success");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}
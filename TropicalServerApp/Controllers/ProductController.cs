using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TropicalServerApp.Models;


namespace TropicalServerApp.Controllers
{
    public class ProductController : Controller
    {
        string connectionString = "Data Source=Wen;Initial Catalog=TropicalServer;Integrated Security=True;";
        DataSet ds = new DataSet();

        //string connectionString = @"Data Source=Wen;Initial Catalog=TropicalServer;Integrated Security=True;";

        // GET: Product

        //public ActionResult TestOrders() {
        //    DataSet ds = new DataSet();
        //    string connectionString = "Data Source=Wen;Initial Catalog=TropicalServer;Integrated Security=True;";
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = connectionString;
        //    SqlCommand cmd = new SqlCommand("Select O.OrdrTrackingNumber, O.OrderDate, C.CustID, C.CustName, C.CustBillingAddress1, C.CustRouteNumber " +
        //            "From dbo.tblCustomer C" +
        //            "Inner Join dbo.tblOrder O ON C.CustNumber = O.OrderCustomerNumber", con);
        //    con.Open();

        //    con.Close();
        //    return View();
        //}

        public ActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Orders()
        {

            //using (TropicalServerEntities1 db = new TropicalServerEntities1()) {
            //    List<tblCustomer> customers = db.tblCustomers.ToList();
            //    List<tblOrder> orders = db.tblOrders.ToList();

            //    var records = from c in customers
            //                  join o in orders on c.CustID equals o.OrderCustomerNumber into table1
            //                  from o in table1.ToList()
            //                  select new ViewModel
            //                  {
            //                      customer = c,
            //                      order = o
            //                  };

            //    return View(records);
            //}

           
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("Select O.OrdrTrackingNumber, O.OrderDate, C.CustID, C.CustName, C.CustBillingAddress1, C.CustRouteNumber " +
                //    "From dbo.tblCustomer C" +
                //    "Inner Join dbo.tblOrder O ON C.CustNumber = O.OrderCustomerNumber", con);
                SqlDataAdapter sqlDa = new SqlDataAdapter(
                    "Select OrderTrackingNumber, TRY_CAST(OrderDate as date) OrderDate, CustID, CustName, CustBillingAddress1, CustRouteNumber From tblOrder INNER Join tblCustomer ON OrderCustomerNumber = CustNumber Where OrderTrackingNumber is not null", con);
                sqlDa.Fill(ds);
                
                con.Close();
            }
            //var result = ds.GetXml();
            //return View(result);
            return View(ds);

            //DataTable dtblOrder = new DataTable();
            //using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
            //    sqlCon.Open();
            //    SqlDataAdapter sqlDa = new SqlDataAdapter(
            //        "Select O.OrdrTrackingNumber, O.OrderDate, C.CustID, C.CustName, C.CustBillingAddress1, C.CustRouteNumber " +
            //        "From dbo.tblCustomer C" +
            //        "Left Join dbo.tblOrder O ON C.CustNumber = O.OrderCustomerNumber", sqlCon
            //        );
            //    sqlDa.Fill(dtblOrder);
            //}
            //return View(dtblOrder);

        }

        public ActionResult ViewDetails() {
            return View("ViewDetails");
        }

        public ActionResult EditDetails() {
            return View("EditDetails");
        }

    }
}
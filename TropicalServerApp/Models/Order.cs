using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TropicalServerApp.Models
{
    public class Order
    {

        [Key]
        int OrderID { get; set; }
        string OrderTrackingNumber { get; set; }
        int OrderRouteNumber { get; set; }
        int OrderCustomerNumber { get; set; }
        string OrderGroupNumber { get; set; }
        int OrderCaseNumbers { get; set; }
        int OrderItemNumber { get; set; }
        decimal OrderPromoNumber { get; set; }
        int OrderItemQty { get; set; }
        decimal ItemUnitPrice { get; set; }
        decimal ItemTotalPrice { get; set; }
        string OrderDate { get; set; }
        string DeliveryDate { get; set; }
        string UserID { get; set; }
        string TabletID { get; set; }
        string DataSyncDateTime { get; set; }
        int OrderConfirmFlag { get; set; }
        int ItemType { get; set; }
        decimal PerPoundItemsWeight { get; set; }



    }
}
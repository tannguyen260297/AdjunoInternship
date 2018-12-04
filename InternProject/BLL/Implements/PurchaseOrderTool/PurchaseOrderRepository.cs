using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternProject.BLL.Interface.PurchaseOrderTool;
using InternProject.DAL.Models.OrderTrack;
using InternProject.DAL.DBContext;
using System.Data.Entity;

namespace InternProject.BLL.Implements.PurchaseOrderTool
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private PODBContext db = new PODBContext();

        public void Add(OrderModel order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}
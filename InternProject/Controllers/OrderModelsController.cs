using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternProject.DAL.DBContext;
using InternProject.DAL.Models.OrderTrack;
using InternProject.BLL.Interface.PurchaseOrderTool;

namespace InternProject.Controllers
{
    public class OrderModelsController : Controller
    {
        private PODBContext db = new PODBContext();

        private IPurchaseOrderRepository IPurchaseOrder;
        public OrderModelsController(IPurchaseOrderRepository purchaseOrderRepository)
        {
            this.IPurchaseOrder = purchaseOrderRepository;
        }

        // GET: OrderModels
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: OrderModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // GET: OrderModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderDate,Company,Supplier,Origin,PortOfLoading,PortOfDelivery,Buyer,Department,OrderType,Season,Factory,Currency,ShipDate,LatestShipDate,DeliveryDate,Mode,Vendor,Status")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orderModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderModel);
        }

        // GET: OrderModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: OrderModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderDate,Company,Supplier,Origin,PortOfLoading,PortOfDelivery,Buyer,Department,OrderType,Season,Factory,Currency,ShipDate,LatestShipDate,DeliveryDate,Mode,Vendor,Status")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }

        // GET: OrderModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: OrderModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel orderModel = db.Orders.Find(id);
            db.Orders.Remove(orderModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

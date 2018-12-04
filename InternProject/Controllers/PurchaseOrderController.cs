using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternProject.ViewModels.PurchaseOrderManager;
using BLL_Layer.BLL.Interface.PurchaseOrderTool;
using DAL_Layer.DAL.Models.OrderTrack;

namespace InternProject.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private IPurchaseOrderRepository PurchaseOrder;

        public PurchaseOrderController() { }

        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrder)
        {
            this.PurchaseOrder = purchaseOrder;
        }

        public ActionResult Create()
        {
            AddModel defaultModel = new AddModel();
            defaultModel.Seasons = GetSelectListItems(SeasonList());
            defaultModel.Origins = GetSelectListItems(new List<string> { "HongKong", "Vietnam" });
            defaultModel.Ports = GetSelectListItems(new List<string> { "Port 1", "Port 2", "Port 3" });
            defaultModel.Modes = GetSelectListItems(new List<string> { "Road", "Sea", "Air" });
            
            return View(defaultModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,Status")] AddModel addModel)
        {
            addModel.Seasons = GetSelectListItems(SeasonList());
            addModel.Origins = GetSelectListItems(new List<string> { "HongKong", "Vietnam" });
            addModel.Ports = GetSelectListItems(new List<string> { "Port 1", "Port 2", "Port 3" });
            addModel.Modes = GetSelectListItems(new List<string> { "Road", "Sea", "Air" });

            if (ModelState.IsValid)
            {
                OrderModel order = new OrderModel();

                order.Id = addModel.Id;
                order.OrderDate = addModel.OrderDate;
                order.Buyer = addModel.Buyer;
                order.Currency = addModel.Currency;
                order.Season = addModel.Season;
                order.Department = addModel.Department;
                order.Vendor = addModel.Vendor;
                order.Company = addModel.Company;
                order.Origin = addModel.Origin;
                order.PortOfLoading = addModel.PortOfLoading;
                order.PortOfDelivery = addModel.PortOfDelivery;
                order.OrderType = addModel.OrderType;
                order.Factory = addModel.Factory;
                order.Mode = addModel.Mode;
                order.ShipDate = addModel.ShipDate;
                order.LatestShipDate = addModel.LatestShipDate;
                order.DeliveryDate = addModel.DeliveryDate;
                order.Status = addModel.Status;

                order.POQuantity = 0;

                order.Supplier = "";

                PurchaseOrder.Add(order);

                return RedirectToAction("Index");
            }

            return View(addModel);
        }

        private IEnumerable<string> SeasonList()
        {
            List<string> seasonList = new List<string>();
            for (int i = 2010; i<=2020; i++)
            {
                seasonList.Add(i.ToString());
            }
            return seasonList;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        // GET: PurchaseOrder
        /*public ActionResult Index()
        {
            List<AddModel> addModels = new List<AddModel>();
            addModels = db.Orders.ToList();
            return View(db.AddModels.ToList());
        }

        // GET: PurchaseOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddModel addModel = db.Orders.Find(id);
            if (addModel == null)
            {
                return HttpNotFound();
            }
            return View(addModel);
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddModel addModel = db.AddModels.Find(id);
            if (addModel == null)
            {
                return HttpNotFound();
            }
            return View(addModel);
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderDate,Buyer,Currency,Season,Department,Vendor,Company,Origin,PortOfLoading,PortOfDelivery,OrderType,Factory,Mode,ShipDate,LatestShipDate,DeliveryDate,POQuantity,Status")] AddModel addModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addModel);
        }

        // GET: PurchaseOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddModel addModel = db.AddModels.Find(id);
            if (addModel == null)
            {
                return HttpNotFound();
            }
            return View(addModel);
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddModel addModel = db.AddModels.Find(id);
            db.AddModels.Remove(addModel);
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
        }*/
    }
}

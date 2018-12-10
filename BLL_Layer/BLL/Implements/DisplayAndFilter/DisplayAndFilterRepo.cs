using BLL_Layer.BLL.Interface;
using BLL_Layer.BLL.Interface.DisplayAndFilter;
using DatabaseRepo;
using DomainModel.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BLL_Layer.BLL.Implements.DisplayAndFilter
{
    public class DisplayAndFilterRepo : IDisplayAndFilterRepo
    {
        private IPODBContext _db;
        public DisplayAndFilterRepo(IPODBContext db)
        {
            this._db = db;
        }

        public DisplayAndFilterRepo()
        { }

        public List<DisplayPO> GetPOs()
        {
            List<DisplayPO> POs = new List<DisplayPO>();
            List<ProgressCheckModel> progressCheckModels = _db.GetDB().ProgressChecks.ToList();
            List<OrderModel> orders = _db.GetDB().Orders.ToList();
            List<OrderDetailModel> orderDetailModels = _db.GetDB().OrderDetails.ToList();
            foreach (var i in orders)
            {
                DisplayPO item = new DisplayPO();
                item.PONumber = i.PONumber;
                item.PODate = i.OrderDate;
                item.Supplier = i.Supplier;
                item.Origin = i.Origin;
                item.PortOfLoading = i.PortOfLoading;
                item.POShipDate = i.ShipDate;
                item.PODeliveryDate = i.DeliveryDate;
                item.PortOfDelivery = i.PortOfDelivery;
                foreach (var j in orderDetailModels)
                {
                    if (j.OrderId == i.Id)
                    {
                        item.POQuantity = j.Quantity;
                    }

                }
                foreach (var y in progressCheckModels)
                {
                    if (y.OrderId == i.Id)
                    {
                        if (y.Complete == true)
                        {
                            item.Status = "Booked";
                        }
                        else
                        {
                            item.Status = "UnBooked";
                        }
                    }
                }
                POs.Add(item);
            }
            return POs;
        }

        public List<DisplayPO> Filter(string key)
        {
            List<DisplayPO> POs = GetPOs();
            List<DisplayPO> lstFilterResul = new List<DisplayPO>();

            foreach (var i in POs)
            {
                if (i.PONumber == key)
                {
                    lstFilterResul.Add(i);
                }
            }

            return lstFilterResul;
        }
    }
}

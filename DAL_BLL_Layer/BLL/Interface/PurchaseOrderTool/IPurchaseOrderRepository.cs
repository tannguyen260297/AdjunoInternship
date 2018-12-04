using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BLL_Layer.DAL.Models.OrderTrack;

namespace DAL_BLL_Layer.BLL.Interface.PurchaseOrderTool
{
    public interface IPurchaseOrderRepository
    {
        void Add(OrderModel order);
    }
}

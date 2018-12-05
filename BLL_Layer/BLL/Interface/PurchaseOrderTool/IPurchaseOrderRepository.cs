using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Layer.DAL.Models.OrderTrack;

namespace BLL_Layer.BLL.Interface.PurchaseOrderTool
{
    public interface IPurchaseOrderRepository
    {
        void Add(OrderModel order);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProject.DAL.Models.OrderTrack;

namespace InternProject.BLL.Interface.PurchaseOrderTool
{
    public interface IPurchaseOrderRepository
    {
        void Add(OrderModel order);
    }
}

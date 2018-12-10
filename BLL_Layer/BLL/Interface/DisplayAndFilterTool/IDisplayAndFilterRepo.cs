using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL_Layer.BLL.Interface.DisplayAndFilter
{
    public interface IDisplayAndFilterRepo
    {
        List<DisplayPO> GetPOs();
        List<DisplayPO> Filter(string key);
    }
}

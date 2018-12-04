using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternProject.DAL.Models.OrderTrack
{
    public class ProgressCheckModel
    {
        [Key]
        [Required]
        public int ID { get; set; }

        //yes/no
        public string Complete { get; set; }

        //yes/no
        public string onSchedule { get; set; }

        //calendar control
        public DateTime IntendedShipDate { get; set; }

        // = sum of all revise quantity?
        public int EstQtyToShip { get; set; }

        //calendar control
        public DateTime InspectionDate { get; set; }

        //max string length
        public string COMMENTS { get; set; }

        [Required]
        [ForeignKey("OrderModel")]
        public int OrderID { get; set; }

        public virtual OrderModel OrderModel { get; set; }
    }
}
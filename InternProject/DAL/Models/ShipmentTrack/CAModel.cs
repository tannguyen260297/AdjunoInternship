using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternProject.DAL.Models.ShipmentTrack
{
    public class CAModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("BookingModel")]
        public int BookingID { get; set; }
        public DateTime ArrivalDate { get; set; }
        [StringLength(20, ErrorMessage = "No more than 20 characters")]
        public string UpdatedBy { get; set; }

        public virtual BookingModel BookingModel { get; set; }
    }
}
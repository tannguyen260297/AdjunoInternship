using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_BLL_Layer.DAL.Models.DeliveryTrack
{
    public class DCConfirmationModel
    {
        [Key]
        public int Id { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DeliveryDate { get; set; }

        [StringLength(12)]
        public string DeliveryTime { get; set; }

    }
}
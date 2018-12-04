using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternProject.DAL.Models.ShipmentTrack
{
    public class BookingModel
    {
        [Key]
        public int ID { get; set; }      
        public string Order { get; set; }
        public int OrderId { get; set; }    
        public string Line { get; set; }   
        public string Item { get; set; }     
        public string Carier { get; set; }     
        public string Vessel { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ETD { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ETA { get; set; }       
        public string Voyage { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be numberic")]
        public int Quantity { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, int.MaxValue, ErrorMessage = "Cartoons must be numberic")]
        public int Cartoons { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Cube must be numberic")]
        public decimal Cube { get; set; }      
        public string PackType { get; set; }       
        public string LoadingType { get; set; }     
        public string Mode { get; set; }        
        public string FreightTerms { get; set; }       
        public string Consignee { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99,ErrorMessage ="GrossWeight must be numberic")]
        public decimal GrossWeight { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingType { get; set; }

    }
}
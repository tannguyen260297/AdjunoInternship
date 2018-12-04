using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternProject.DAL.Models.ShipmentTrack
{
    public class ManifestModel
    {
        [Key]
        //[Column(Order = 1)]
        public int ID { get; set; }
        [ForeignKey("BookingModel")]
        public int BookingID { get; set; }

        
        public string Seal { get; set; }

        /*[Key]
        [Column(Order = 2)]*/
        public string Container { get; set; }

        
        public string Loading { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be numberic")]
        public int Bars { get; set; }
        public string Equipment { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be numberic")]
        public int Quantity { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, int.MaxValue, ErrorMessage = "Cartoons must be numberic")]
        public int Cartoons { get; set; }

        public string Cartons { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Cube must be numberic")]
        public decimal Cube { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "KGS must be numberic")]
        public decimal KGS { get; set; }
        public string FreightTerms { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "ChargeableKGS must be numberic")]
        public decimal ChargeableKGS { get; set; }
        public string PackType { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "NetKGS must be numberic")]
        public decimal NetKGS { get; set; }
        public virtual BookingModel BookingModel { get; set; }

    }
}
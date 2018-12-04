using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternProject.DAL.Models.OrderTrack
{
    public class OrderModel
    {
        [Key]
        [Required]
        [Display(Name = "PO Number")]
        [Range(0, 10 ^ 11 - 1)] //up to 10 digits
        //[IDValidation] //Validate Uniqueness
        public int ID { get; set; }

        private DateTime defaultOrderDate = DateTime.Now;

        //DropList from 2010 to 2020
        //Default value is Current Date *unfinished*
        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate
        {
            get
            {
                return defaultOrderDate;
            }
            set
            {
                defaultOrderDate = value;
            }
        }
        //public DateTime OrderDate { get; set; } = DateTime.Now;

        //Company&Supplier?
        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Company { get; set; }

        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Supplier { get; set; }

        //Droplist Vietnam-HongKong
        [Required]
        public string Origin { get; set; }

        [Required]
        [Display(Name = "Port of Loading")]
        public string PortOfLoading { get; set; }

        [Required]
        [Display(Name = "Port of Delivery")]
        //[PoDeliveryValidation] //PoD must be different from PoL *unfinished*
        public string PortOfDelivery { get; set; }

        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Buyer { get; set; }

        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Department { get; set; }

        [Display(Name = "Order Type")]
        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string OrderType { get; set; }

        //Droplist from 2010 to 2020
        public string Season { get; set; }

        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Factory { get; set; }

        //Default value = USD
        public string Currency { get; set; } = "USD";

        [Display(Name = "Ship Date")]
        public DateTime ShipDate { get; set; }

        [Display(Name = "Latest Ship Date")]
        //Similar or later than ShipDate *unfinished*
        public DateTime LatestShipDate { get; set; }

        [Display(Name = "Delivery Date")]
        //Similar or later than ShipDate *unfinished*
        public DateTime DeliveryDate { get; set; }

        //DropList Road-Sea-Air
        public string Mode { get; set; }

        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string Vendor { get; set; }

        //sum of all PODetails Quantity *not sure if correct*
        private List<OrderDetailModel> PODetails { get; set; }
        [Display(Name = "PO Quantity")]
        public float POQuantity
        {
            get
            {
                float sum = 0;
                foreach (var POItem in PODetails)
                {
                    sum += POItem.Quantity;
                }

                return sum;
            }
        }

        //Default value = "New"
        public string Status { get; set; } = "New";
    }
}
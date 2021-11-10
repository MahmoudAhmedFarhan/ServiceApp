using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject2.Models
{
    public class RequestModel
    {
        public int RequestId { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public System.DateTime RequestDate { get; set; }
        public double Qty { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}

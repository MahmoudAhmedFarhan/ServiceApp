//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceApi2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VwServiceProvider
    {
        public int ProvicderId { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public decimal ServiceCost { get; set; }
        public int ServiceId { get; set; }
        public string ImageName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceIcon { get; set; }
        public Nullable<double> Rating { get; set; }
    }
}
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
    
    public partial class TbServiceProvider
    {
        public int ServiceId { get; set; }
        public int ProviderId { get; set; }
        public decimal ServiceCost { get; set; }
    
        public virtual TbProvider TbProvider { get; set; }
        public virtual TbService TbService { get; set; }
    }
}

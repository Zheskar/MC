//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManaCena.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductLocation
    {
        public int Id { get; set; }
        public Nullable<int> ProductSaleId { get; set; }
        public Nullable<int> LocationId { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual ProductSale ProductSale { get; set; }
    }
}

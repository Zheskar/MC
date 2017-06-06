//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManaCena.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellerId { get; set; }
        public Nullable<int> CathegoryId { get; set; }
        public Nullable<decimal> OriginalPrice { get; set; }
        public Nullable<decimal> DiscountPrice { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Seller Seller { get; set; }
        public virtual Cathegory Cathegory { get; set; }
    }
}

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
        public Product()
        {
            this.ProductAds = new HashSet<ProductAd>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Wheight { get; set; }
        public Nullable<int> Unit { get; set; }
        public string Size { get; set; }
        public Nullable<int> CathegoryId { get; set; }
    
        public virtual ICollection<ProductAd> ProductAds { get; set; }
        public virtual Cathegory Cathegory { get; set; }
    }
}
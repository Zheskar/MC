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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductSales = new HashSet<ProductSale>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CathegoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Wheight { get; set; }
        public Nullable<int> Unit { get; set; }
        public string Size { get; set; }
        public Nullable<int> ProductImageId { get; set; }
        public Nullable<int> ProductImageSmallId { get; set; }
    
        public virtual Cathegory Cathegory { get; set; }
        public virtual ProductImage ProductImage { get; set; }
        public virtual ProductImageSmall ProductImageSmall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}

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
            this.ProductLocations = new HashSet<ProductLocation>();
        }
    
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Name_Lat { get; set; }
        public string Name_Rus { get; set; }
        public string Description { get; set; }
        public string Description_Rus { get; set; }
        public string Description_Lat { get; set; }
        public Nullable<decimal> Wheight { get; set; }
        public Nullable<int> Unit { get; set; }
        public string Size { get; set; }
        public Nullable<int> ProductImageId { get; set; }
        public Nullable<int> ProductImageSmallId { get; set; }
        public Nullable<decimal> OriginalPrice { get; set; }
        public Nullable<decimal> DiscountPrice { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> SubCathegoryId { get; set; }
        public Nullable<int> CathegoryId { get; set; }
        public Nullable<int> CathegoryTypeId { get; set; }
    
        public virtual Cathegory Cathegory { get; set; }
        public virtual CathegoryType CathegoryType { get; set; }
        public virtual ProductImage ProductImage { get; set; }
        public virtual ProductImageSmall ProductImageSmall { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual SubCathegory SubCathegory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLocation> ProductLocations { get; set; }
    }
}

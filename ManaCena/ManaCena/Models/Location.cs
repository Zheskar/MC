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
    
    public partial class Location
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
    
        public virtual Seller Seller { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.CouponOrder = new HashSet<CouponOrder>();
            this.Costumer = new HashSet<Costumer>();
        }
    
        public int Id { get; set; }
        public CategoryTypes category { get; set; }
    
        public virtual ICollection<CouponOrder> CouponOrder { get; set; }
        public virtual ICollection<Costumer> Costumer { get; set; }
    }
}

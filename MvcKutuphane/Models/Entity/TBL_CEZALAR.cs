//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_CEZALAR
    {
        public int ID { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<System.DateTime> CEZABASLANGIC { get; set; }
        public Nullable<System.DateTime> CEZABITIS { get; set; }
        public Nullable<decimal> PARA { get; set; }
        public Nullable<int> HAREKET { get; set; }
    
        public virtual TBL_HAREKET TBL_HAREKET { get; set; }
        public virtual TBL_UYELER TBL_UYELER { get; set; }
    }
}

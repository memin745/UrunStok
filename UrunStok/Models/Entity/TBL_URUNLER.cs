//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_URUNLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_URUNLER()
        {
            this.TBL_SATIS = new HashSet<TBL_SATIS>();
        }
    
        public int URUNID { get; set; }
        public string URUNAD { get; set; }
        public string MARKA { get; set; }
        public Nullable<short> URUNKATEGORİ { get; set; }
        public Nullable<decimal> URUNFİYAT { get; set; }
        public Nullable<byte> STOK { get; set; }
    
        public virtual TBL_KATEGORİLER TBL_KATEGORİLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SATIS> TBL_SATIS { get; set; }
    }
}
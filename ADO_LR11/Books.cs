//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADO_LR11
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int ID_BOOK { get; set; }
        public string NameBook { get; set; }
        public int ID_THEME { get; set; }
        public int ID_AUTHOR { get; set; }
        public decimal Price { get; set; }
        public int DrowingOfBook { get; set; }
        public System.DateTime DateOfPublish { get; set; }
        public int Pages { get; set; }
        public int QuantityBooks { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual Themes Themes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_queja_estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_queja_estado()
        {
            this.tbl_queja = new HashSet<tbl_queja>();
        }
    
        public int IdQueja_estado { get; set; }
        public string qe_descripcion { get; set; }
        public bool qe_se_modifica { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_queja> tbl_queja { get; set; }
    }
}

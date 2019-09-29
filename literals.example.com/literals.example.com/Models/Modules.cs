using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace literals.example.com.Models
{
    public partial class Modules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modules()
        {
            Literals = new HashSet<Literals>();
        }

        [StringLength(20)]
        public string Name { get; set; }

        [Key]
        public Guid ModuleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Literals> Literals { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace literals.example.com.Models
{
    public class Literals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Literals()
        {
            LiteralTranslations = new HashSet<LiteralTranslations>();
            Variables = new HashSet<Variables>();
        }

        [Key]
        public Guid LiteralID { get; set; }

        public Guid ModuleID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        public bool Plural { get; set; }

        [Required]
        [StringLength(30)]
        public string ExampleURL { get; set; }

        public virtual Modules Modules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiteralTranslations> LiteralTranslations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Variables> Variables { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace literals.example.com.Models
{
    public class Countries
    {        
        public Countries()
        {
            LiteralTranslations = new HashSet<LiteralTranslations>();
        }

        [Key]
        public Guid CountryID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        public virtual ICollection<LiteralTranslations> LiteralTranslations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace literals.example.com.Models
{    

    public class Languages
    {
        public Languages()
        {
            LiteralTranslations = new HashSet<LiteralTranslations>();
        }

        [Key]
        public Guid LanguageID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<LiteralTranslations> LiteralTranslations { get; set; }
    }
}

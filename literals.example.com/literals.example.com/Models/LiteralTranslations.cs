using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace literals.example.com.Models
{  

    public class LiteralTranslations
    {
        [Key]
        public Guid LiteralTranslationID { get; set; }

        public Guid LanguageID { get; set; }

        public Guid? CountryID { get; set; }

        public Guid LiteralID { get; set; }

        [StringLength(50)]
        public string ValueZero { get; set; }

        [StringLength(50)]
        public string ValueOne { get; set; }

        [StringLength(50)]
        public string ValueMany { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual Languages Languages { get; set; }

        public virtual Literals Literals { get; set; }
    }
}

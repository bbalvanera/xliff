using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace literals.example.com.Models
{
    public partial class Variables
    {
        [Key]
        public Guid VariableID { get; set; }

        public Guid LiteralID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Literals Literals { get; set; }
    }
}

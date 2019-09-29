using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace literals.example.com.Models
{
    public class Modules
    {       
        public Modules()
        {
            Literals = new HashSet<Literals>();
        }

        [StringLength(20)]
        public string Name { get; set; }

        [Key]
        public Guid ModuleID { get; set; }
        
        public virtual ICollection<Literals> Literals { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace literals.example.com.Models
{
    public class LiteralsContext: DbContext
    {
        public LiteralsContext()
        {
        }
        public LiteralsContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Countries> countries { get; set; }
        public DbSet<Languages> languages { get; set; }
        public DbSet<Literals> literals { get; set; }
        public DbSet<LiteralTranslations> literalTranslations { get; set; }
        public DbSet<Modules> modules { get; set; }
        public DbSet<Variables> variables { get; set; }

    }
}

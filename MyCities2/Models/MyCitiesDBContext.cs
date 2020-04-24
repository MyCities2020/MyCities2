using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCities2.Models
{
    public class MyCitiesDBContext : DbContext
    {
        public MyCitiesDBContext(DbContextOptions<MyCitiesDBContext> options ) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<Batiment> BatimentCulturel { get; set; } 
        public DbSet<Batiment> BatimentReligieux { get; set; } 
        public DbSet<Batiment> DetalsArchitecture { get; set; } 
        public DbSet<Batiment> User { get; set; } 



    }
}

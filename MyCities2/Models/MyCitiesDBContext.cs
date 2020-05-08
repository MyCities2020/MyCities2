using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCities2.Models;

namespace MyCities2.Models
{
    public class MyCitiesDBContext : DbContext
    {
        public MyCitiesDBContext(DbContextOptions<MyCitiesDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<BatimentCulturel> BatimentsCulturel { get; set; } 
        public DbSet<BatimentReligieux> BatimentsReligieux { get; set; } 
        public DbSet<DetailsArchitecture> DetailsArchitecture { get; set; } 
        public DbSet<User> Users { get; set; } 

    }
}

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
        public MyCitiesDBContext(DbContextOptions<MyCitiesDBContext> options ) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<BatimentCulturel> BatimentsCulturel { get; set; } 
        public DbSet<BatimentReligieux> BatimentsReligieux { get; set; } 
        public DbSet<DetailsArchitecture> DetailsArchitecture { get; set; } 
        public DbSet<User> Users { get; set; } 
        //public DbSet<MyCities2.Models.BatimentCulturel> BatimentCulturel_1 { get; set; }
        //public DbSet<MyCities2.Models.BatimentReligieux> BatimentReligieux_1 { get; set; }
        //public DbSet<MyCities2.Models.DetailsArchitecture> DetailsArchitecture { get; set; }
        //public DbSet<MyCities2.Models.User> User_1 { get; set; }



    }
}

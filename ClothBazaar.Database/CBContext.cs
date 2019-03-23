using ClothBazaar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazaar.Database
{
  public  class CBContext:DbContext 
    {
        public CBContext():base("ClothBazaarConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

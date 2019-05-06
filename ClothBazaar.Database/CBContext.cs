using ClothBazaar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazaar.Database
{
  public  class CBContext:DbContext,IDisposable //Entity Framework ki ek class hoti ha DbContext us sy inherit kren gy.
    {
        public CBContext():base("ClothBazaarConnection") //ctor// k ye connection string use krnii ha or ye entities use krni hai database generate krny k liye.
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

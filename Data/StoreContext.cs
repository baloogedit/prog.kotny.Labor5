using System;
using System.Collections.Generic;
using System.Data.Entity; // Use the EF6 namespace
using Labor_5.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_5.Data
{
    // Inherit from the classic DbContext
    public class StoreContext : DbContext
    {
        // This tells EF6 to use a connection string from App.config
        // named "StoreContext". If one isn't found, it will create
        // a LocalDB database by convention.
        public StoreContext() : base("name=StoreContext")
        {
        }

        // This DbSet represents your "Products" table
        public DbSet<Product> Products { get; set; }
    }
}

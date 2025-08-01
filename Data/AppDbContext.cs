using Microsoft.EntityFrameworkCore;
using ShippingServices.Model;


namespace ShippingServices.Data

{

    public class AppDbContext : DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ShippingItem> ShippingItems { get; set; }

    }

}


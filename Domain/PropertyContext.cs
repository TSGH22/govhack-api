namespace GovHack22API.Domain {
    
    using GovHack22API.Models;
    using Microsoft.EntityFrameworkCore;

    public class PropertyContext : DbContext
    {
        
        public DbSet<Property> Properties { get; set; }


        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)  
        {   
        }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
        }  
    }
}


using E470CodeChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace E470CodeChallenge.DbContexts
{
    /// <summary>
    /// The db context for the E-470 Challenge. Storage was not mentioned in the specification. Normally I would ask about this. However 
    /// for this purpose of this challenge, I wanted the data to be able to actually save, and in this case to an in memory database using
    ///  EF. 
    /// </summary>
    public class E470DbContext : DbContext
    {
        /// <summary>
        /// Vehicles table, stated for dummy in spec. Normal story I would confirm I am not working with data in this story. 
        /// For the purpose of a challenge, I thought it best to include storage of the information. 
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }
        
        /// <summary>
        /// The transponders that are created and linked to a vehicle.  
        /// </summary>
        public DbSet<Transponder> Transponders { get; set;}


        /// <summary>
        /// parameterless contructor used for testing.
        /// </summary>
        public E470DbContext() : base()
        {
        }

        /// <summary>
        /// The constructor for the DB context.
        /// </summary>
        /// <param name="options">Options for the context.</param>
        public E470DbContext(DbContextOptions<E470DbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Used to generate the in memory database code first.
        /// </summary>
        /// <param name="modelBuilder">The model builder used for configuration of the database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config is minimal since there was no storage stated in the ask. I just wanted to have some storeage so used in memory
            //Mostly want to show that I understand foreign key.
            
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();
            });

            modelBuilder.Entity<Transponder>(entity =>
            {
                     entity.HasOne(t => t.Vehicle)
                      .WithOne(v => v.Transponder)
                      .HasForeignKey<Transponder>(t => t.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

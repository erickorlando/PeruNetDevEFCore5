using Microsoft.EntityFrameworkCore;
using PeruNetDev.Entities;
using PeruNetDev.Entities.EntitiesFromSql;

namespace PeruNetDev.DataLayer
{
    public class PeruNetDevDbContext : DbContext
    {
        public PeruNetDevDbContext(DbContextOptions<PeruNetDevDbContext> options)
        : base(options)
        {

        }

        public PeruNetDevDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactInfo>()
                .HasNoKey();

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactInfo> Addresses { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VidaSana.API.Application.Models;

namespace VidaSana.API.Infrastructure
{
    public class VidaSanaContext : DbContext
    {

        const string DEFAULT_SCHEMA = "vida_sana";

        public DbSet<ClientData> Clients { get; set; }


        public VidaSanaContext(DbContextOptions<VidaSanaContext> options) : base(options)
        {
            base.Database.EnsureCreated();
            base.SaveChanges();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientData>(ConfigureClient);


        }

        private void ConfigureClient(EntityTypeBuilder<ClientData> requestConfiguration)
        {
            requestConfiguration.ToTable("Clients", DEFAULT_SCHEMA);

            requestConfiguration.HasKey(c => c.Document);

            requestConfiguration.Property(c => c.CompleteName)
                .HasMaxLength(260)
               .IsRequired()
               .HasColumnName("CompleteName");

            requestConfiguration.Property(c => c.Birthdate)
               .HasMaxLength(15)
               .IsRequired()
               .HasColumnName("Birthdate");
        }


    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebServiceBlazorCrud.ModelsEntityFramework
{
    public partial class blazorcrudContext : DbContext
    {
        public blazorcrudContext()
        {
        }

        public blazorcrudContext(DbContextOptions<blazorcrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cerveza> Cerveza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=blazorcrud");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cerveza>(entity =>
            {
                entity.ToTable("cerveza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

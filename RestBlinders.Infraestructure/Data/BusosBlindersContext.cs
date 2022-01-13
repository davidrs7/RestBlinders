using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestBlinders.Core.Entities;
using RestBlinders.Infraestructure.Data.configurations;

#nullable disable

namespace RestBlinders.Infraestructure.Data
{
    public partial class BusosBlindersContext : DbContext
    {
        public BusosBlindersContext()
        {
        }

        public BusosBlindersContext(DbContextOptions<BusosBlindersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InvColore> InvColores { get; set; }
        public virtual DbSet<InvInventario> InvInventarios { get; set; }
        public virtual DbSet<InvReferencia> InvReferencias { get; set; }
        public virtual DbSet<InvTalla> InvTallas { get; set; }
        public virtual DbSet<InvTipiden> InvTipidens { get; set; }
        public virtual DbSet<InvVendedore> InvVendedores { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new coloresConfiguration());

            modelBuilder.ApplyConfiguration(new inventarioConfiguration());

            modelBuilder.ApplyConfiguration(new referenciasConfiguration());

            modelBuilder.ApplyConfiguration(new tallasConfiguration());

            modelBuilder.ApplyConfiguration(new tipIdenConfiguration());

            modelBuilder.ApplyConfiguration(new vendedoresConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

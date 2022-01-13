using System;
using System.Collections.Generic;
using System.Text;
using RestBlinders.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RestBlinders.Infraestructure.Data.configurations
{
    public class inventarioConfiguration : IEntityTypeConfiguration<InvInventario>
    {
        public void Configure(EntityTypeBuilder<InvInventario> builder)
        {
            builder.HasKey(e => e.InventarioCodigo);                               
                    

            builder.ToTable("INV_INVENTARIO");

            builder.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

            builder.Property(e => e.ColorCodigo).HasColumnName("COLOR_CODIGO");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.InventarioCodigo)
                .ValueGeneratedOnAdd()
                .HasColumnName("INVENTARIO_CODIGO");

            builder.Property(e => e.RefCodigo).HasColumnName("REF_CODIGO");

            builder.Property(e => e.TallaCodigo).HasColumnName("TALLA_CODIGO");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");

            builder.HasOne(d => d.ColorCodigoNavigation)
                .WithMany()
                .HasForeignKey(d => d.ColorCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_INVEN__COLOR__40F9A68C");

            builder.HasOne(d => d.RefCodigoNavigation)
                .WithMany()
                .HasForeignKey(d => d.RefCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_INVEN__REF_C__3F115E1A");

            builder.HasOne(d => d.TallaCodigoNavigation)
                .WithMany()
                .HasForeignKey(d => d.TallaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_INVEN__TALLA__40058253");
        }
    }
}

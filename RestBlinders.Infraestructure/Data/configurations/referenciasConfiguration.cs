using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestBlinders.Core.Entities;

namespace RestBlinders.Infraestructure.Data.configurations
{
    public class referenciasConfiguration : IEntityTypeConfiguration<InvReferencia>
    {
        public void Configure(EntityTypeBuilder<InvReferencia> builder)
        {
            builder.HasKey(e => e.RefCodigo)
                     .HasName("INV_REFERENCIAS_REF_CODIGO_PK");

            builder.ToTable("INV_REFERENCIAS");

            builder.Property(e => e.RefCodigo).HasColumnName("REF_CODIGO");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.RefDescripcion)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REF_DESCRIPCION");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");
        }
    }
}

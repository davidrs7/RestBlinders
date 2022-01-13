using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBlinders.Core.Entities;

namespace RestBlinders.Infraestructure.Data.configurations
{
    public class tallasConfiguration : IEntityTypeConfiguration<InvTalla>
    {
        public void Configure(EntityTypeBuilder<InvTalla> builder)
        {
            builder.HasKey(e => e.TallaCodigo)
                  .HasName("INV_REFERENCIAS_TALLA_CODIGO_PK");

            builder.ToTable("INV_TALLAS");

            builder.Property(e => e.TallaCodigo).HasColumnName("TALLA_CODIGO");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.TallaDescripcion)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TALLA_DESCRIPCION");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");
        }
    }
}

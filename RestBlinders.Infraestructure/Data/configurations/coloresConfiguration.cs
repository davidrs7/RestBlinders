using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBlinders.Core.Entities;


namespace RestBlinders.Infraestructure.Data.configurations
{
    public class coloresConfiguration : IEntityTypeConfiguration<InvColore>
    {
        public void Configure(EntityTypeBuilder<InvColore> builder)
        {
            builder.HasKey(e => e.ColorCodigo)
                   .HasName("INV_REFERENCIAS_COLOR_CODIGO_PK");

            builder.ToTable("INV_COLORES");

            builder.Property(e => e.ColorCodigo).HasColumnName("COLOR_CODIGO");

            builder.Property(e => e.ColorCodigoHtml)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COLOR_CODIGO_HTML");

            builder.Property(e => e.ColorDescripcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("COLOR_DESCRIPCION");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");
        }
    }
}

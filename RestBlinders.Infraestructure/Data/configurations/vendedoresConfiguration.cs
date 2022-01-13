using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBlinders.Core.Entities;

namespace RestBlinders.Infraestructure.Data.configurations
{
    public class vendedoresConfiguration : IEntityTypeConfiguration<InvVendedore>
    {
        public void Configure(EntityTypeBuilder<InvVendedore> builder)
        {
            builder.HasKey(e => e.VendedorCodigo)
                .HasName("INV_VENDEDORES_VENDEDOR_CODIGO_PK");

            builder.ToTable("INV_VENDEDORES");

            builder.Property(e => e.VendedorCodigo).HasColumnName("VENDEDOR_CODIGO");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");

            builder.Property(e => e.VendedorActivo).HasColumnName("VENDEDOR_ACTIVO");

            builder.Property(e => e.VendedorApellidos)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_APELLIDOS");

            builder.Property(e => e.VendedorDireccion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_DIRECCION");

            builder.Property(e => e.VendedorIdentificacion)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_IDENTIFICACION");

            builder.Property(e => e.VendedorNombres)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_NOMBRES");

            builder.Property(e => e.VendedorTelefono)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_TELEFONO");

            builder.Property(e => e.VendedorTipiden).HasColumnName("VENDEDOR_TIPIDEN");

            builder.HasOne(d => d.VendedorTipidenNavigation)
                .WithMany(p => p.InvVendedores)
                .HasForeignKey(d => d.VendedorTipiden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_VENDE__VENDE__45BE5BA9");
        }
    }
}

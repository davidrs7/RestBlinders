using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestBlinders.Core.Entities;

namespace RestBlinders.Infraestructure.Data.configurations
{
    public class tipIdenConfiguration : IEntityTypeConfiguration<InvTipiden>
    {
        public void Configure(EntityTypeBuilder<InvTipiden> builder)
        {
            builder.HasKey(e => e.TipidenCodigo)
                  .HasName("INV_TIPIDEN_TIPIDEN_CODIGO_PK");

            builder.ToTable("INV_TIPIDEN");

            builder.Property(e => e.TipidenCodigo).HasColumnName("TIPIDEN_CODIGO");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.TipidenDesctipcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TIPIDEN_DESCTIPCION");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_AT");
        }
    }
}

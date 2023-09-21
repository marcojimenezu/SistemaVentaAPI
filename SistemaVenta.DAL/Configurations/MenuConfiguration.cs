using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class MenuConfiguration: IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> entity)
    {
        entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483C8AA5070");

        entity.ToTable("Menu");

        entity.Property(e => e.IdMenu).HasColumnName("idMenu");
        entity.Property(e => e.Icono)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("icono");
        entity.Property(e => e.Nombre)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("nombre");
        entity.Property(e => e.Url)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("url");
    }
}
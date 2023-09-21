using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class MenuRolConfiguration : IEntityTypeConfiguration<MenuRol>
{
    public void Configure(EntityTypeBuilder<MenuRol> entity)
    {
        entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A47D0D6F87");

        entity.ToTable("MenuRol");

        entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
        entity.Property(e => e.IdMenu).HasColumnName("idMenu");
        entity.Property(e => e.IdRol).HasColumnName("idRol");

        entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
            .HasForeignKey(d => d.IdMenu)
            .HasConstraintName("FK__MenuRol__idMenu__3C69FB99");

        entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
            .HasForeignKey(d => d.IdRol)
            .HasConstraintName("FK__MenuRol__idRol__3D5E1FD2");
    }
}
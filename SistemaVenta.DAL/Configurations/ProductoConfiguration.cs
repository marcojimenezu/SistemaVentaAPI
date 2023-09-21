using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> entity)
    {
        entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132C2B18C54");

        entity.ToTable("Producto");

        entity.Property(e => e.IdProducto).HasColumnName("idProducto");
        entity.Property(e => e.EsActivo)
            .HasDefaultValueSql("((1))")
            .HasColumnName("esActivo");
        entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("fechaRegistro");
        entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
        entity.Property(e => e.Nombre)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("nombre");
        entity.Property(e => e.Precio)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("precio");
        entity.Property(e => e.Stock).HasColumnName("stock");

        entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
            .HasForeignKey(d => d.IdCategoria)
            .HasConstraintName("FK__Producto__idCate__48CFD27E");
    }
}
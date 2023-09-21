using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> entity)
    {
        entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__BFE2843F451EAF7C");

        entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
        entity.Property(e => e.Cantidad).HasColumnName("cantidad");
        entity.Property(e => e.IdProducto).HasColumnName("idProducto");
        entity.Property(e => e.IdVenta).HasColumnName("idVenta");
        entity.Property(e => e.Precio)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("precio");
        entity.Property(e => e.Total)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("total");

        entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
            .HasForeignKey(d => d.IdProducto)
            .HasConstraintName("FK__DetalleVe__idPro__5441852A");

        entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
            .HasForeignKey(d => d.IdVenta)
            .HasConstraintName("FK__DetalleVe__idVen__534D60F1");
    }
}
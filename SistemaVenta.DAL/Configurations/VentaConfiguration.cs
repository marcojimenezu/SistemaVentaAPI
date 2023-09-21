using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> entity)
    {
        entity.HasKey(e => e.IdVenta).HasName("PK__Venta__077D5614C40D08A1");

        entity.Property(e => e.IdVenta).HasColumnName("idVenta");
        entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("fechaRegistro");
        entity.Property(e => e.NumeroDocumento)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("numeroDocumento");
        entity.Property(e => e.TipoPago)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("tipoPago");
        entity.Property(e => e.Total)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("total");
    }
}
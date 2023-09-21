using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class NumeroDocumentoConfiguration : IEntityTypeConfiguration<NumeroDocumento>
{
    public void Configure(EntityTypeBuilder<NumeroDocumento> entity)
    {
        entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NumeroDocumento");

        entity.ToTable("NumeroDocumento");

        entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");
        entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("fechaRegistro");
        entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
    }
}
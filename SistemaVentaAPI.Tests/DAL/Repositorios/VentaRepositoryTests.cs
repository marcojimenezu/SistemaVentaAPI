using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SistemaVenta.DAL.Repositorios;
using SistemaVenta.Model;
using SistemaVentaAPI.Tests.Fixtures;
using Xunit;

namespace SistemaVentaAPI.Tests.DAL.Repositorios;

public class VentaRepositoryTests : IClassFixture<DatabaseFixture>
{
    public VentaRepositoryTests(DatabaseFixture dbFixture)
    {
        _dbFixture = dbFixture;
    }
    private DatabaseFixture _dbFixture;
    
    [Fact]
    public async Task ShouldReturnsNewSaleWhenRegistrarWithAVentaAndDetailsIsCalled()
    {
        var sut = new VentaRepository(_dbFixture.DbVentaContext);
        var stockProduct1 = _dbFixture.DbVentaContext.Productos.First(p => p.IdProducto == 1).Stock;
        var quantity1 = 2;
        var stockProduct2 = _dbFixture.DbVentaContext.Productos.First(p => p.IdProducto == 2).Stock;
        var quantity2 = 1;
        var venta = new Venta
        {
            DetalleVenta =
            {
                new DetalleVenta
                {
                    IdProducto = 1,
                    Cantidad = quantity1,
                    Precio = 99.99m,
                    Total = quantity1 * 99.99m
                },
                new DetalleVenta
                {
                    IdProducto = 2,
                    Cantidad = quantity2,
                    Precio = 888.99m,
                    Total = quantity2 * 888.99m
                }
            }
        };

        var result = await sut.Registrar(venta);
        
        result.Should().NotBeNull();
        result.IdVenta.Should().NotBe(0);
        result.NumeroDocumento.Should().MatchRegex("\\d{4}");
        result.DetalleVenta.Count.Should().Be(2);
        _dbFixture.DbVentaContext.Productos.First(p => p.IdProducto == 1).Stock.Should().Be(stockProduct1 - quantity1);
        _dbFixture.DbVentaContext.Productos.First(p => p.IdProducto == 2).Stock.Should().Be(stockProduct2 - quantity2);
        // result.FechaRegistro.Should().NotBeNull();
        // result.Total.Should().Be(venta.DetalleVenta.First().Total);
    }
    
}
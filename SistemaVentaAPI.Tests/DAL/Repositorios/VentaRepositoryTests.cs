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
    public async Task ShouldReturnsNewSaleWhenRegistrarWithAVentaIsCalled()
    {
        var sut = new VentaRepository(_dbFixture.DbVentaContext);
        var venta = new Venta();

        var result = await sut.Registrar(venta);
        
        result.Should().NotBeNull();
        result.IdVenta.Should().Be(1);
        result.NumeroDocumento.Should().Be("0001");
    }
}
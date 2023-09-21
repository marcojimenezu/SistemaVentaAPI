using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Repositorios
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly DbventaContext _dbcontext;

        public VentaRepository(DbventaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();
            var productIds = modelo.DetalleVenta
                .Select(p => new {p.IdProducto, p.Cantidad})
                .ToDictionary(t => t.IdProducto, t => t.Cantidad);
            var products = _dbcontext.Productos.Where(p => productIds.Keys.Contains(p.IdProducto)).ToList();
            foreach (Producto product in products)
            {
                product.Stock -= productIds[product.IdProducto];
            }

            NumeroDocumento? correlativo = _dbcontext.NumeroDocumentos.FirstOrDefault();
            if (correlativo is null)
            {
                correlativo = new NumeroDocumento();
                _dbcontext.NumeroDocumentos.Add(correlativo);
            }

            correlativo.UltimoNumero += 1;
            correlativo.FechaRegistro = DateTime.Now;

            const int cantidadDigitos = 4;
            string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
            modelo.NumeroDocumento = correlativo.UltimoNumero.ToString(ceros);

            await _dbcontext.Venta.AddAsync(modelo);
            await _dbcontext.SaveChangesAsync();

            ventaGenerada = modelo;

            return ventaGenerada;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;
using SistemaVenta.Utility;

namespace SistemaVenta.BLL.Servicios
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IVentaRepository _ventaRepositorio;
        private readonly IGenericRepository<Producto> _productoRepositorio;
        private readonly IMapper _mapper;
        private const int WeakDays = -7;

        public DashBoardService(IVentaRepository ventaRepository,
            IGenericRepository<Producto> productoRepositorio,
            IMapper mapper)
        {
            _ventaRepositorio = ventaRepository;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            var salesTable = await _ventaRepositorio.Consultar();
            var hasSales = salesTable.Any();
            if (!hasSales)
            {
                return new DashBoardDTO
                {
                    TotalIngresos = 0.ToMXString()
                };
            }

            var lastSaleDate = await salesTable
                .OrderByDescending(v => v.FechaRegistro)
                .Select(v => v.FechaRegistro)
                .FirstAsync();

            var vmDashBoard = new DashBoardDTO
            {
                TotalVentas = await TotalVentasUltimaSemana(salesTable, lastSaleDate),
                TotalIngresos = await TotalIngresosUltimaSemana(salesTable, lastSaleDate),
                TotalProductos = await CountProducts(),
                VentasUltimaSemana = await VentasUltimaSemana(salesTable, lastSaleDate)
            };

            return vmDashBoard;
        }

        private async Task<int> TotalVentasUltimaSemana(IQueryable<Venta> salesQuery, DateTime? lastSaleDate)
        {
            var query = BuildFilterByDateRange(salesQuery, lastSaleDate, WeakDays);
            return await query.CountAsync();
        }

        private async Task<string> TotalIngresosUltimaSemana(IQueryable<Venta> salesQuery, DateTime? lastSaleDate)
        {
            var query = BuildFilterByDateRange(salesQuery, lastSaleDate, WeakDays);
            var result = await query.Select(v => v.Total).SumAsync(v => v ?? 0);
            return result.ToMXString();
        }

        private async Task<List<VentaSemanaDTO>> VentasUltimaSemana(IQueryable<Venta> salesQuery,
            DateTime? lastSaleDate)
        {
            var query = BuildFilterByDateRange(salesQuery, lastSaleDate, WeakDays);
            var result = await query
                .GroupBy(v => v.FechaRegistro.Value.Date)
                .OrderBy(g => g.Key)
                .Select(dv => new VentaSemanaDTO
                {
                    Fecha = dv.Key.ToString(Constans.DateFormat),
                    Total = dv.Count()
                })
                .ToListAsync();
            return result;
        }

        private async Task<int> CountProducts()
        {
            var productQuery = await _productoRepositorio.Consultar();
            return await productQuery.CountAsync();
        }

        private IQueryable<Venta> BuildFilterByDateRange(IQueryable<Venta> salesTable, DateTime? lastSaleDate,
            int period)
        {
            lastSaleDate = lastSaleDate.Value.AddDays(period);
            return salesTable.Where(v => v.FechaRegistro.Value.Date >= lastSaleDate.Value.Date);
        }
    }
}
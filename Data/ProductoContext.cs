using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockElectronica.Models;

namespace StockElectronica.Data
{
    public class ProductoContext : DbContext
    {
        public ProductoContext (DbContextOptions<ProductoContext> options)
            : base(options)
        {
        }

        public DbSet<StockElectronica.Models.Producto> Producto { get; set; } = default!;

        public DbSet<StockElectronica.Models.NumeroSerie> NumeroSerie { get; set; } = default!;

        public DbSet<StockElectronica.Models.Marca> Marca { get; set; } = default!;
        
    }
}

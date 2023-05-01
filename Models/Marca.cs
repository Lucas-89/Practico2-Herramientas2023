using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockElectronica.Models
{
    public class Marca
    {
        public int Id{get;set;}
        public string NombreMarca{get;set;}
        public string Origen {get;set;}
        public List<Producto> Productos{get;}= new List<Producto>();
    }
}
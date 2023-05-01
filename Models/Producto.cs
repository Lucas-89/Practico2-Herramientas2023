using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockElectronica.Models
{
    public class Producto
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        //public string Marcas {get;set;} // cambiarlo a una lista de marcas
        public int NumeroSerieId {get;set;}
        public virtual NumeroSerie NumeroSerie {get;set;}
        public List<Marca> Marcas{get;}=new List<Marca>();
    }
}
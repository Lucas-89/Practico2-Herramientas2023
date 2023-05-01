using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockElectronica.Models
{
    public class Modelo
    {
        public int Id{get;set;}
        public string Nombre {get;set;}
        public string MarcaId{get;set;}
        public virtual Marca Marca{get;set;}
        
    }
}
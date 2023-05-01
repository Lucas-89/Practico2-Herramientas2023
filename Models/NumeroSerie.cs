using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockElectronica.Models
{
    public class NumeroSerie
    {
        public int Id{get;set;}
        public string ProdId{get;set;}
        public virtual Producto producto{get;set;}
        public string ParNumer{get;set;}
        
    }
}
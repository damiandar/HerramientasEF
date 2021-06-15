using System.Collections.Generic;
namespace ProyMVC.Models
{
    public class Sucursal
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public string Ciudad{get;set;}
        public virtual List<Producto> Productos {get;set;}
    }
}
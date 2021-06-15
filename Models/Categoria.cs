using System.Collections.Generic;

namespace ProyMVC.Models
{
    public class Categoria
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public virtual List<Producto> Productos {get;set;}
    }
}
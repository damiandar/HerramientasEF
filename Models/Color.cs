using System.Collections.Generic;

namespace ProyMVC.Models
{
    public class Color
    {
        public int Id{get;set;}
        public string Nombre{get;set;}
        public virtual List<Producto> Productos{get;set;}
    }
}
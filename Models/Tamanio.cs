using System.Collections.Generic;
namespace ProyMVC.Models
{
    public class Tamanio
    {
        public int Id{get;set;}
        public string Descripcion{get;set;}
        public string Medida{get;set;}
        public virtual List<Producto> Productos{get;set;}
    }
}
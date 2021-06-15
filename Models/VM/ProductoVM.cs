using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProyMVC.Models.VM
{
    public class ProductoVM
    {
        public Producto Producto {get;set;}
        public List<Tamanio> Tamanios {get;set;}

        public List<Categoria> Categorias {get;set;}

        public IFormFile FotoFormulario{get;set;}
    }
}
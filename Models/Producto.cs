using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProyMVC.Models
{
    public class Producto
    {
        public int Id {get;set;}
        public string Nombre{get;set;}
        public string Marca{get;set;}
        public double Precio{get;set;}
        public string Descripcion{get;set;}

        public int CategoriaId {get;set;}
        public Categoria Categoria{get;set;}


        public virtual List<Color> Colores{get;set;}
        public virtual List<Sucursal> Sucursales{get;set;}



        public int TamanioId {get;set;}
        public Tamanio Tamanio {get;set;}


        [DefaultValue("sinfoto.jpg")]
        public string FotoRuta {get;set;}

        [NotMapped()]
        public IFormFile Foto{get;set;}

    }
}
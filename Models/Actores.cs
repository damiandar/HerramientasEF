using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyMVC.Models
{
    public partial class Actores
    {
        public Actores()
        {
            ActorPeliculas = new HashSet<ActorPeliculas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FotoRuta {get;set;}
        [NotMapped()]
        public IFormFile Foto {get;set;}

        public virtual Bios Bios { get; set; }
        public virtual ICollection<ActorPeliculas> ActorPeliculas { get; set; }
    }
}

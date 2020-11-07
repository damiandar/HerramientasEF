using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class PeliculasDto
    {
   

        public int Id { get; set; }
        public int Duracion { get; set; }
        public int Anio { get; set; }
        public string Titulo { get; set; }
        public string GeneroNombre {get;set;}

        public List<Actores> Actores {get;set;}

        //public int? GeneroId { get; set; }

        //public virtual Generos Genero { get; set; }
        //public virtual ICollection<ActorPeliculas> ActorPeliculas { get; set; }
    }
}

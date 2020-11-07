using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class Peliculas
    {
        public Peliculas()
        {
            ActorPeliculas = new HashSet<ActorPeliculas>();
        }

        public int Id { get; set; }
        public int Duracion { get; set; }
        public int Anio { get; set; }
        public string Titulo { get; set; }
        public int? GeneroId { get; set; }

        public virtual Generos Genero { get; set; }
        public virtual ICollection<ActorPeliculas> ActorPeliculas { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class ActorPeliculas
    {
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }

        public virtual Actores Actor { get; set; }
        public virtual Peliculas Pelicula { get; set; }
    }
}

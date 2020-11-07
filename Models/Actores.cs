using System;
using System.Collections.Generic;

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

        public virtual Bios Bios { get; set; }
        public virtual ICollection<ActorPeliculas> ActorPeliculas { get; set; }
    }
}

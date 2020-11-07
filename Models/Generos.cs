using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class Generos
    {
        public Generos()
        {
            Peliculas = new HashSet<Peliculas>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}

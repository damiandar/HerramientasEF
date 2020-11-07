using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class ActorDto
    {
     
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Bios Bio {get;set;}

        public string Origen {get;set;}
        public List<PeliculasDto> Pelis{get;set;}

        //public virtual Bios Bios { get; set; }
        //public virtual ICollection<ActorPeliculas> ActorPeliculas { get; set; }
    }
}

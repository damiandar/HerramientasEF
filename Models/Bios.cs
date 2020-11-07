using System;
using System.Collections.Generic;

namespace ProyMVC.Models
{
    public partial class Bios
    {
        public int BioId { get; set; }
        public string Origen { get; set; }
        public string EstadoCivil { get; set; }
        public int Edad { get; set; }
        public int ActorId { get; set; }

        public virtual Actores Actor { get; set; }
    }
}

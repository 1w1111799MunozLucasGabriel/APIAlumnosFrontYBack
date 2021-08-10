using System;
using System.Collections.Generic;

#nullable disable

namespace Alumnos3.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int SexoId { get; set; }
        public string Sexo1 { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}

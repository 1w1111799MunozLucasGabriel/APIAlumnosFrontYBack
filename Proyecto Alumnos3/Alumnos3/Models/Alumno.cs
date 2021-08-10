using System;
using System.Collections.Generic;

#nullable disable

namespace Alumnos3.Models
{
    public partial class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Curso { get; set; }
        public int? SexoId { get; set; }

        public virtual Sexo Sexo { get; set; }
    }
}

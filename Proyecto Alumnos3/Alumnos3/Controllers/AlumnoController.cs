using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alumnos3.Models;
using Microsoft.AspNetCore.Cors;
using Resultados;
using Comandos.Alumnos;

namespace Alumnos3.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class AlumnoController : ControllerBase
    {
        private readonly alumnospr3Context db = new alumnospr3Context();
        // READ ALUMNOS
        [HttpGet]
        [Route("Alumnos/ObtenerAlumnos")]
        public ActionResult<ResultadoAPI> get()
        {
            var resultado = new ResultadoAPI();
            try 
            {
                resultado.Ok = true;
                resultado.Return = db.Alumnos.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Error al encontrar usuarios";

                return resultado;
            }
        }
        // READ SEXOS
        [HttpGet]
        [Route("Alumnos/ObtenerSexos")]
        public ActionResult<ResultadoAPI> getSexos()
        {
            var resultado = new ResultadoAPI();
            try 
            {
                resultado.Ok = true;
                resultado.Return = db.Sexos.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Error al encontrar sexos";

                return resultado;
            }
        }

        // CREATE   
        [HttpPost]
        [Route("Alumnos/CrearAlumno")]

        public ActionResult<ResultadoAPI> PostAlumno([FromBody]ComandoCrearAlumno comando)
        {
            var resultado = new ResultadoAPI();
                 // ejemplo validacion en back  ---- dejarlas para ultimo momentosi esq sobra tiempo
            if(comando.Nombre.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre";
                return resultado;
            } 
             if(comando.Apellido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Apellido";
                return resultado;
            } 

            if(comando.Curso.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Curso";
                return resultado;
            } 
            //funcion CREATE basica
            var alumno = new Alumno();
            alumno.Nombre = comando.Nombre;
            alumno.Apellido = comando.Apellido;
            alumno.Curso = comando.Curso;
            alumno.SexoId = comando.SexoId;

            db.Alumnos.Add(alumno);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return  =db.Alumnos.ToList();

            return resultado;
        }


// GetById   
        [HttpGet]
        [Route("Alumnos/GetAlumnoId/{idAlumno}")]

        public ActionResult<ResultadoAPI> getByID(int idAlumno)
        {
            var resultado = new ResultadoAPI();
             try {
                 var alumno = db.Alumnos.Where(c => c.AlumnoId == idAlumno).FirstOrDefault();
                 resultado.Ok = true;
                 resultado.Return = alumno;

                 return resultado;
             }
             catch (Exception ex)
             {
                 resultado.Ok = false;
                 resultado.CodigoError = 1;
                 resultado.Error = "Alumno no encontrado en la base de datos - " + ex.Message;

                 return resultado;
             }
        }
    
    
// PUT (Update)
 [HttpPut] 
 [Route("Alumnos/UpdateAlumno")]

 public ActionResult<ResultadoAPI> UpdateAlumno([FromBody]ComandoUpdateAlumno comando) 
 {
     var resultado = new ResultadoAPI();

     if(comando.Curso.Equals(""))
      {
          resultado.Ok = false;
          resultado.Error = "ingrese su curso";
          return resultado;
      }

      var alumno = db.Alumnos.Where(c => c.AlumnoId == comando.AlumnoId).FirstOrDefault();
      if (alumno != null)
      {
          alumno.Curso = comando.Curso;
          db.Alumnos.Update(alumno);
          db.SaveChanges();
      }
      resultado.Ok = true;
      resultado.Return = db.Alumnos.ToList();

      return resultado;
 }

// DELETE
[HttpDelete]
[Route("Alumnos/DeleteAlumno/{idAlumno}")]
public ActionResult<ResultadoAPI> deleteById(int idAlumno)
{
    var resultado = new ResultadoAPI();
    var alumno = db.Alumnos.Where(c => c.AlumnoId == idAlumno).FirstOrDefault();
    db.Alumnos.Remove(alumno);
    db.SaveChanges();

    resultado.Ok = true;
    resultado.Return = db.Alumnos.ToList();
    return resultado;



}
        }
}

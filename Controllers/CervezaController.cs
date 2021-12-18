using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBlazorCrud.ModelsEntityFramework.Response;
using WebServiceBlazorCrud.ModelsEntityFramework;
using WebServiceBlazorCrud.ModelsEntityFramework.Request;
namespace WebServiceBlazorCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Cerveza>> oRespuesta = new Respuesta<List<Cerveza>>();

            try
            {


                using (blazorcrudContext db = new blazorcrudContext())
                {

                    var lst = db.Cerveza.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }

            }
            catch (Exception ex) {

                oRespuesta.Mensaje = ex.Message;

            }
                return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Cerveza> oRespuesta = new Respuesta<Cerveza>();

            try
            {


                using (blazorcrudContext db = new blazorcrudContext())
                {

                    var lst = db.Cerveza.Find(Id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(CervezaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {


                using (blazorcrudContext db = new blazorcrudContext())
                {

                    Cerveza oCerveza = new Cerveza(); // clase cerveza dentro de models, creado con el comando de scaffold
                    oCerveza.Marca = model.Marca;
                    oCerveza.Nombre = model.Nombre;
                    db.Cerveza.Add(oCerveza);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut] //editar
        public IActionResult Edit(CervezaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {


                using (blazorcrudContext db = new blazorcrudContext())
                {

                    Cerveza oCerveza = db.Cerveza.Find(model.Id);
                    oCerveza.Marca = model.Marca;
                    oCerveza.Nombre = model.Nombre;
                    db.Entry(oCerveza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpDelete("{Id}")] //eliminar
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {


                using (blazorcrudContext db = new blazorcrudContext())
                {

                    Cerveza oCerveza = db.Cerveza.Find(Id);
                    db.Remove(oCerveza);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApIGius.Class;
using WebApIGius.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApIGius.Controllers
{
    [Produces("application/json")]
    public class MunicipiosController : Controller
    {
        MunicipiosDataAccess Da = new MunicipiosDataAccess();

        // GET: api/<controller>
        [HttpGet]
        [Route("Municipios/list-byIndice")]
        public IActionResult GetListaByIndice([FromQuery]int municipioNumero)
        {
            ///<param name="municipioNumero"> El id del Principal del Municipio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de los municipios y podemos filtrar por el Id del Municipio
            /// </summary>
            /// <returns> Retorna Una Lista de Municipios </returns>

            IList<MunicipiosList> listaMunicipios = new List<MunicipiosList>();
            try
            {
                listaMunicipios = Da.getMunicipiosListFindByKey(municipioNumero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(listaMunicipios);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Municipios/new-municipio")]
        public IActionResult PostMunicipio([FromBody]MunicipiosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un Municipio
            /// </summary>
            /// <returns> Retorna Un Objeto con el municipio que se creo </returns>

            MunicipiosList municipio = new MunicipiosList();
            try
            {
                municipio = Da.PostMunicipiosInsert(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(municipio);
           //  return Ok(municipio);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Route("Municipios/update-municipio")]
        public IActionResult PutMunicipio(int id, [FromBody]MunicipiosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="municipioNumero">El Id del municipio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Municipio
            /// </summary>
            /// <returns> Retorna Un Objeto con el municipio que se actualizó </returns>

            MunicipiosList municipio = new MunicipiosList();
            try
            {
                municipio = Da.PutMuncipiosUpdate(id, value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(municipio);
        }

    }
}

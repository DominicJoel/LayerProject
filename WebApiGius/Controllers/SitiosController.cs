using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIGius.Data;
using WebApIGius.Interfaces;
using WebApIGius.Models;

namespace WebApIGius.Controllers
{
    [Produces("application/json")]
    public class SitiosController : Controller
    {
        ISitiosInterface Da = new SitiosDataAccess();

        [HttpGet]
        [Route("Sitio/Estado/list-byIndice")]
        public IActionResult GetListaSitioEstadoByIndice([FromQuery]int estadoNumero)
        {
            ///<param name="estadoNumero"> El id del Principal del EstadoSitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de los estados de los sitios y podemos filtrar por el Id del SitioEstado
            /// </summary>
            /// <returns> La lista lista de los estados de los sitios  y la lista de los estados de los sitios filtradas por el estadoNumero </returns>

            #region Lista de los Estados de los sitios
            IList<SitiosEstadosList> listaSitioEstados = new List<SitiosEstadosList>();
            try
            {
                listaSitioEstados = Da.GetSitiosEstadosListFindByKey(estadoNumero);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            return Ok(listaSitioEstados);
            #endregion
        }

        [HttpPost]
        [Route("Sitio/Estado/new-estado")]
        public IActionResult PostSitioEstado([FromBody]SitiosEstadosList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un estado de un Sitio
            /// </summary>
            ///<returns> Retorna el objeto que se insertó </returns>

            #region Insertar un estado de un sitio
            SitiosEstadosList sitioEstado = new SitiosEstadosList();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    sitioEstado = Da.PostSitiosEstadosListInsert(values);
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioEstado);
            #endregion
        }

        [HttpPut("{id}")]
        [Route("Sitio/Estado/update-estado")]
        public IActionResult PutSitioEstado(int id, [FromBody]SitiosEstadosList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="id">El Id del Estado que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Estado de los sitios
            /// </summary>
            /// <returns> Retorna el objeto actualizado </returns>

            #region Actualizar un estado de un sitio
            SitiosEstadosList sitioEstado = new SitiosEstadosList();
            try
            {
                sitioEstado = Da.PutSitiosEstadosListUpdate(id, values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioEstado);

            #endregion
        }

        [HttpGet]
        [Route("Sitio/list-byIndice")]
        public IActionResult GetListaSitiosMainByIndice([FromQuery]int sitioNumero)
        {
            ///<param name="sitioNumero"> El id del Principal del Sitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista  de los sitios y podemos filtrar por el Id del Sitio
            /// </summary>
            /// <returns> La lista lista de los sitios  y la lista de los  sitios filtradas por el sitioNumero </returns>

            #region Lista de los sitios
            IList<SitiosMain> listaSitios = new List<SitiosMain>();
            try
            {
                listaSitios = Da.GetSitiosMainFindByKey(sitioNumero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(listaSitios);
            #endregion
        }

        [HttpPost]
        [Route("Sitio/new-sitio")]
        public IActionResult PostSitio([FromBody]SitiosMain values)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un Sitio
            /// </summary>
            ///<returns> Retorna el objeto que se insertó </returns>

            #region Insertar un sitio
            SitiosMain sitioMain = new SitiosMain();
            try
            {
                sitioMain = Da.PostSitiosMainInsert(values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioMain);
            #endregion
        }

        [HttpPut("{id}")]
        [Route("Sitio/update-sitio")]
        public IActionResult PutSitio(int id, [FromBody]SitiosMain values)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="id">El Id del sitio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un sitio
            /// </summary>
            /// <returns> Retorna el objeto actualizado </returns>

            #region Actualizar un sitio
            SitiosMain sitioMain = new SitiosMain();
            try
            {
                sitioMain = Da.PutSitiosMainUpdate(id, values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioMain);

            #endregion
        }

        [HttpGet]
        [Route("Sitio/Tipo/list-byIndice")]
        public IActionResult GetListaSitiosTipoByIndice([FromQuery]int tipoNumero)
        {
            ///<param name="tipoNumero"> El id del Principal del tipo de Sitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista  de los tipos de sitios y podemos filtrar por el Id del tipo de Sitio
            /// </summary>
            /// <returns> La lista de los tipos de sitios  y la lista de los tipos filtradas por el tipoNumero </returns>

            #region Lista de los tipos de sitio
            IList<SitiosTiposList> listaSitiosTipo = new List<SitiosTiposList>();
            try
            {
                listaSitiosTipo = Da.GetSitioTiposListFindByKey(tipoNumero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(listaSitiosTipo);
            #endregion
        }

        [HttpPost]
        [Route("Sitio/Tipo/new-tipo")]
        public IActionResult PostSitioTipo([FromBody]SitiosTiposList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un tipo de Sitio
            /// </summary>
            ///<returns> Retorna el objeto que se insertó </returns>

            #region Insertar un tipo de sitio
            SitiosTiposList sitioMain = new SitiosTiposList();
            try
            {
                sitioMain = Da.PostSitioTipoInsert(values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioMain);
            #endregion
        }

        [HttpPut("{id}")]
        [Route("Sitio/update-sitio")]
        public IActionResult PutSitioTipo(int id, [FromBody]SitiosTiposList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="id">El Id del tipo de sitio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un tipo de sitio
            /// </summary>
            /// <returns> Retorna el objeto actualizado </returns>

            #region Actualizar un sitio
            SitiosTiposList sitioTipo = new SitiosTiposList();
            try
            {
                sitioTipo = Da.PutSitioTipoUpdate(id, values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sitioTipo);

            #endregion
        }
    }
}
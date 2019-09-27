using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastucture.Models;
using Microsoft.AspNetCore.Mvc;
using WebApIGius.Class;
using WebApIGius.Interfaces;
using WebApIGius.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApIGius.Controllers
{
    [Produces("application/json")]
    public class AreaController : Controller
    {
        
        IAreaInterface _da;
        public AreaController(IAreaInterface da)
        {
            _da = da;
        }
        // IAreaInterface Da = new AreaDataAccess(null);

        // GET: api/<controller>
        [HttpGet]
        [Route("Areas/list-byIndice")]
        public IActionResult GetListaByIndice([FromQuery]int areaNumero)
        {
            ///<param name="areaNumero"> El id del Principal del area </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de las areas y podemos filtrar por el Id del Area
            /// </summary>
            /// <returns> La lista de las areas y la lista de las areas filtradas por el indice </returns>

            #region Lista de Areas
            IList<AreasList> listaAreas = new List<AreasList>();
            try
            {
               // IAreaInterface Da2 = new AreaDataAccess(_context);
                listaAreas = _da.getAreasListFindByKey(areaNumero);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            return Ok(listaAreas);
            #endregion
        }

        [HttpGet]
        [Route("Areas/list-byQuerry")]
        public IActionResult GetListaByQuery([FromQuery] int pageIndex, int pageSize, string areaNombre, int ordenar)
        {
            ///<param name="areaNombre"> Nombre del Area </param>
            ///<param name="ordenar"></param>
            ///<param name="pageIndex"> Indice de la pagina </param>
            ///<param name="pageSize"> Y el Tamano de la pagina  </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de las areas y podemos filtrar por un campo en especifico y poder paginar
            /// </summary>
            /// <returns> Retorna la lista de las areas y una lista filtrada por un campo en especifico y poder paginar </returns>

            #region Filtro y Lista de areas
            IList<AreasFilterList> listaAreas = new List<AreasFilterList>();
            try
            {
                listaAreas = _da.getAreasListFindByQuery(pageIndex, pageSize, areaNombre, ordenar);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            return Ok(listaAreas);
            #endregion
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Areas/new-area")]
        public IActionResult PostArea([FromBody]AreasList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un area
            /// </summary>
            ///<returns> Retorna el objeto que se insertó </returns>

            #region Insertar Area
            AreasList area = new AreasList();
            try
                {
                   area = _da.PostAreasInsert(values);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            return Ok(area);
            #endregion
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Route("Areas/update-area")]
        public IActionResult PutArea(int id ,[FromBody]AreasList values)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="areaNumero">El Id del area que será actualizada </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un area
            /// </summary>
            /// <returns> Retorna el objeto actualizado </returns>
            
            #region Actualizar un area
            AreasList area = new AreasList();
            try
            {
                area = _da.PutAreasUpdate(id, values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(area);

            #endregion
        }

    }
}

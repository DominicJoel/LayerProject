using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIGius.Interfaces;
using WebApIGius.Models;

namespace WebApIGius.Class
{
    public class AreaDataAccess: IAreaInterface
    {

        Octal_GIUContext _context;

        public AreaDataAccess(Octal_GIUContext context)
        {
            _context = context;
        }


        public IList<AreasList> getAreasListFindByKey(int areaNumero)
        {
            ///<param name="areaNumero"> El id del Principal del area </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de las areas y podemos filtrar por el Id del Area
            /// </summary>

            IList<AreasList> areasList = new List<AreasList>();
            using (_context)
            {
                try
                {
                    areasList = _context.AreasList.FromSql($"exec Areas_List_Find_By_Key { areaNumero }").ToList();
                    return areasList;
                }
                catch ( Exception ex )
                {
                     throw ex;
                }    
            }
        }

        public IList<AreasFilterList> getAreasListFindByQuery( int pageIndex, int pageSize, string areaNombre, int ordenar)
        {
            ///<param name="areaNombre"> Nombre del Area </param>
            ///<param name="ordenar"></param>
            ///<param name="pageIndex"> Indice de la pagina </param>
            ///<param name="pageSize"> Y el Tamano de la pagina  </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de las areas y podemos filtrar por un campo en especifico y poder paginar
            /// </summary>

            IList<AreasFilterList> areasList = new List<AreasFilterList>();
            using (var context = new Octal_GIUContext())
            {
                try
                {              
                    areasList = context.LoadStoredProc("dbo.Areas_List_Query")// Nombre del Procedimiento
                          .WithSqlParam("@PageIndex", pageIndex)
                          .WithSqlParam("@PageSize", pageSize)
                          .WithSqlParam("@Area_Nombre", areaNombre)
                          .WithSqlParam("@Ordenar", ordenar)
                          .ExecuteStoredProc<AreasFilterList>();

                    return areasList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public AreasList PostAreasInsert(AreasList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un area
            /// </summary>

            AreasList area = new AreasList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    area = context.AreasList
                                 .FromSql($"exec Areas_List_Insert { value.AreaNumero },{ value.SitioNumero }, { value.AreaClienteId },{ value.AreaNombre },{ value.AreaObjetivo },{ value.AreaUnidades },{ value.AreaLatitud },{ value.AreaLongitud },{ value.SeguridadQuien },{ value.SeguridadIp }")
                                 .FirstOrDefault();
                    return area;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public AreasList PutAreasUpdate(int areaNumero ,AreasList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="areaNumero">El Id del area que será actualizada </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un area
            /// </summary>

            AreasList areasList = new AreasList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    areasList = context.AreasList
                                       .FromSql($"exec Areas_List_Update { areaNumero },{ value.SitioNumero },{ value.AreaClienteId },{ value.AreaNombre },{ value.AreaObjetivo },{ value.AreaUnidades },{ value.AreaLatitud },{ value.AreaLongitud },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIp } ")
                                       .FirstOrDefault();
                    return areasList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}


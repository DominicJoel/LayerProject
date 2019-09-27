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
    public class SectoresParajesDataAccess: ISectoresParajesInterface
    {
        public IList<SectoresParajesList> getSectoresParajesListFindByKey(int sectorSecuencia)
        {
            ///<param name="sectorSecuencia"> El id del Principal del Paraje </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de los Sectores Parajes y podemos filtrar por el sectorSecuencia del Paraje
            /// </summary>

            IList<SectoresParajesList> sectoresParajesList = new List<SectoresParajesList>();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sectoresParajesList = context.SectoresParajesList.FromSql($"exec Sectores_Parajes_List_Find_By_Key { sectorSecuencia }").ToList();
                    return sectoresParajesList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SectoresParajesList PostSectoresParajesInsert(SectoresParajesList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un Paraje de un sector
            /// </summary>

            SectoresParajesList sectorParaje = new SectoresParajesList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sectorParaje = context.SectoresParajesList.FromSql($"exec Municipios_List_Insert { value.SectorSecuencia },{ value.MunicipioNumero }, { value.SectorNumero },{ value.SectorNombre }, { value.CiudadNumero },{ value.SeguridadQuien },{ value.SeguridadIp}").FirstOrDefault();
                    return sectorParaje;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SectoresParajesList PutSectoresParajesUpdate(int sectorSecuencia, SectoresParajesList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="sectorSecuencia">El Id del Paraje que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Paraje
            /// </summary>

            SectoresParajesList municipio = new SectoresParajesList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    municipio = context.SectoresParajesList.FromSql($"exec Sectores_Parajes_List_Update { sectorSecuencia },{ value.MunicipioNumero },{ value.SectorNumero },{ value.SectorNombre },{ value.CiudadNumero },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIp}").FirstOrDefault();
                    return municipio;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

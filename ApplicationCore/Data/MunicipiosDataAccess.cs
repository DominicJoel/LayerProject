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
    public class MunicipiosDataAccess:IMunicipioInterface
    {
        public IList<MunicipiosList> getMunicipiosListFindByKey(int municipioNumero)
        {
            ///<param name="municipioNumero"> El id del Principal del Municipio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de los municipios y podemos filtrar por el Id del Municipio
            /// </summary>

            IList<MunicipiosList> municipioList = new List<MunicipiosList>();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    municipioList = context.MunicipiosList.FromSql($"exec Municipios_List_Find_By_Key { municipioNumero }").ToList();
                    return municipioList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public MunicipiosList PostMunicipiosInsert(MunicipiosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un Municipio
            /// </summary>

            MunicipiosList municipio = new MunicipiosList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    municipio = context.MunicipiosList
                                       .FromSql($"exec Municipios_List_Insert { value.MunicipioNumero },{ value.MunicipioNombre },{ value.MunicipioProvinciaNombre },{ value.ProvinciaNumero },{ value.ProvinciaNombre },{ value.RegionGeograficaNumero },{ value.SeguridadQuien },{ value.SeguridadIpc}")
                                       .FirstOrDefault();

                    return municipio;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public MunicipiosList PutMuncipiosUpdate(int municipioNumero, MunicipiosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="municipioNumero">El Id del municipio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Municipio
            /// </summary>

            MunicipiosList municipio = new MunicipiosList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    municipio = context.MunicipiosList
                                       .FromSql($"exec Municipios_List_Update { municipioNumero },{ value.MunicipioNombre },{ value.MunicipioProvinciaNombre },{ value.ProvinciaNumero },{ value.ProvinciaNombre },{ value.RegionGeograficaNumero },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIpc}")
                                       .FirstOrDefault();
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

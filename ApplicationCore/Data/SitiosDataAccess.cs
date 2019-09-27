using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApIGius.Interfaces;
using WebApIGius.Models;

namespace WebApIGius.Data
{
    public class SitiosDataAccess: ISitiosInterface
    {
        public IList<SitiosEstadosList> GetSitiosEstadosListFindByKey(int estadoNumero)
        {
            ///<param name="estadoNumero"> El id Principal de los estados del sitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista de los estados de los sitios y podemos filtrar por el Id del Sitio
            /// </summary>

            IList<SitiosEstadosList> sitiosEstadoList = new List<SitiosEstadosList>();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitiosEstadoList = context.SitiosEstadosList.FromSql($"exec Sitios_Estados_List_Find_By_Key { estadoNumero }").ToList();
                    return sitiosEstadoList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosEstadosList PostSitiosEstadosListInsert(SitiosEstadosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un Estado de un sitio
            /// </summary>

            SitiosEstadosList sitioEstado = new SitiosEstadosList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioEstado = context.SitiosEstadosList
                                         .FromSql($"exec Sitios_Estados_List_Insert  { value.EstadoCodigo },{ value.EstadoDespcricion },{ value.EstadoExplicacion },{ value.EstadoPublicar },{ value.EstadoListar },{ value.EstadoCriterio },{ value.SeguridadQuien },{ value.SeguridadIpc }")
                                         .FirstOrDefault();
                    return sitioEstado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosEstadosList PutSitiosEstadosListUpdate(int estadoNumero, SitiosEstadosList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="estadoNumero">El Id del Estado que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Estado de un sitio
            /// </summary>

            SitiosEstadosList sitioEstadoList = new SitiosEstadosList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioEstadoList = context.SitiosEstadosList
                                       .FromSql($"exec Sitios_Estados_List_Update  { estadoNumero },{ value.EstadoCodigo },{ value.EstadoDespcricion },{ value.EstadoExplicacion },{ value.EstadoPublicar },{ value.EstadoListar },{ value.EstadoCriterio },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIpc}")
                                       .FirstOrDefault();

                    return sitioEstadoList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IList<SitiosMain> GetSitiosMainFindByKey(int sitioNumero)
        {
            ///<param name="sitioNumero"> El id Principal del sitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista  de los sitios y podemos filtrar por el Id del Sitio
            /// </summary>

            IList<SitiosMain> sitiosMain = new List<SitiosMain>();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitiosMain = context.SitiosMain.FromSql($"exec Sitios_Main_Find_By_Key { sitioNumero }").ToList();
                    return sitiosMain;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosMain PostSitiosMainInsert(SitiosMain value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar  un sitio
            /// </summary>

            SitiosMain sitioMain = new SitiosMain();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioMain = context.SitiosMain
                                       .FromSql($"exec Sitios_Main_Insert { value.SitioNumero },{ value.SitioClienteId },{ value.TipoNumero },{ value.SitioNombre },{ value.SitioDescripcion },{ value.MunicipioDireccionNumero },{ value.SitioDireccion },{ value.SectorSecuencia },{ value.SitioDireccionProximo },{ value.SitioDireccionLatitud },{ value.SitioDireccionLongitud },{ value.SitioTelefonoUno },{ value.SitioTelefonoDos },{ value.EstadoNumero },{ value.SeguridadQuien },{ value.SeguridadIp } ")
                                       .FirstOrDefault();

                    return sitioMain;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosMain PutSitiosMainUpdate(int sitioNumero, SitiosMain value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="sitioNumero">El Id del sitio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un Sitio
            /// </summary>

            SitiosMain sitioMain = new SitiosMain();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioMain = context.SitiosMain
                                       .FromSql($"exec Sitios_Main_Update  { sitioNumero },{ value.SitioClienteId },{ value.TipoNumero },{ value.SitioNombre },{ value.SitioDescripcion },{ value.MunicipioDireccionNumero },{ value.SitioDireccion },{ value.SectorSecuencia },{ value.SitioDireccionProximo },{ value.SitioDireccionLatitud },{ value.SitioDireccionLongitud },{ value.SitioTelefonoUno },{ value.SitioTelefonoDos },{ value.EstadoNumero },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIp}")
                                       .FirstOrDefault();

                    return sitioMain;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IList<SitiosTiposList> GetSitioTiposListFindByKey(int tipoNumero)
        {
            ///<param name="tipoNumero"> El id Principal del tipo de  sitio </param>
            /// <summary> 
            /// Este metodo se encarga de retornar la lista  de los tipo de sitios y podemos filtrar por el Id del tipo
            /// </summary>

            IList<SitiosTiposList> sitiosTipo = new List<SitiosTiposList>();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitiosTipo = context.SitiosTiposList.FromSql($"exec Sitios_Tipos_List_Find_By_Key { tipoNumero }").ToList();
                    return sitiosTipo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosTiposList PostSitioTipoInsert(SitiosTiposList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para guardar </param>
            /// <summary> 
            /// Este metodo se encarga de insertar un tipo de sitio
            /// </summary>

            SitiosTiposList sitioTipo = new SitiosTiposList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioTipo = context.SitiosTiposList
                                       .FromSql($"exec Sitios_Tipos_List_Insert  { value.TipoNumero },{ value.TipoDespcricion },{ value.TipoExplicacion },{ value.TipoPublicar },{ value.TipoListar },{ value.TipoPrefijo },{ value.TipoCriterio },{ value.TipoUnidad },{ value.SeguridadQuien },{ value.SeguridadIpc } ")
                                       .FirstOrDefault();
                    return sitioTipo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SitiosTiposList PutSitioTipoUpdate(int tipoNumero, SitiosTiposList value)
        {
            ///<param name="value"> El objeto con los campos necesarios para actualizar </param>
            ///<param name="tipoNumero">El Id del tipo de sitio que será actualizado </param>
            /// <summary> 
            /// Este metodo se encarga de actualizar un tipo de Sitio
            /// </summary>

            SitiosTiposList sitioTipo = new SitiosTiposList();
            using (var context = new Octal_GIUContext())
            {
                try
                {
                    sitioTipo = context.SitiosTiposList
                                       .FromSql($"exec Sitios_Tipos_List_Update   { tipoNumero },{ value.TipoDespcricion },{ value.TipoExplicacion },{ value.TipoPublicar },{ value.TipoListar },{ value.TipoPrefijo },{ value.TipoCriterio },{ value.TipoUnidad },{ value.SeguridadQuien },{value.SeguridadEstado},{ value.SeguridadIpc}")
                                       .FirstOrDefault();

                    return sitioTipo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}

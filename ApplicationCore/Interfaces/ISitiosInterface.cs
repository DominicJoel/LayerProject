using System;
using System.Collections.Generic;
using WebApIGius.Models;

namespace WebApIGius.Interfaces
{
    public interface ISitiosInterface
    {
        IList<SitiosEstadosList> GetSitiosEstadosListFindByKey(int estadoNumero);
        SitiosEstadosList PostSitiosEstadosListInsert(SitiosEstadosList value);
        SitiosEstadosList PutSitiosEstadosListUpdate(int estadoNumero, SitiosEstadosList value);
        IList<SitiosMain> GetSitiosMainFindByKey(int sitioNumero);
        SitiosMain PostSitiosMainInsert(SitiosMain value);
        SitiosMain PutSitiosMainUpdate(int sitioNumero, SitiosMain value);
        IList<SitiosTiposList> GetSitioTiposListFindByKey(int tipoNumero);
        SitiosTiposList PostSitioTipoInsert(SitiosTiposList value);
        SitiosTiposList PutSitioTipoUpdate(int tipoNumero, SitiosTiposList value);
    }
}

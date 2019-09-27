using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIGius.Models;

namespace WebApIGius.Interfaces
{
    public interface ISectoresParajesInterface
    {
        IList<SectoresParajesList> getSectoresParajesListFindByKey(int sectorSecuencia);
        SectoresParajesList PostSectoresParajesInsert(SectoresParajesList value);
        SectoresParajesList PutSectoresParajesUpdate(int sectorSecuencia, SectoresParajesList value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIGius.Models;

namespace WebApIGius.Interfaces
{
    public interface IAreaInterface
    {
        IList<AreasList> getAreasListFindByKey(int areaNumero);
        IList<AreasFilterList> getAreasListFindByQuery(int pageIndex, int pageSize, string areaNombre, int ordenar);
        AreasList PostAreasInsert(AreasList value);
        AreasList PutAreasUpdate(int areaNumero, AreasList value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIGius.Models;

namespace WebApIGius.Interfaces
{
    public interface IMunicipioInterface
    {
        IList<MunicipiosList> getMunicipiosListFindByKey(int municipioNumero);
        MunicipiosList PostMunicipiosInsert(MunicipiosList value);
        MunicipiosList PutMuncipiosUpdate(int municipioNumero, MunicipiosList value);
    }
}

using System;
using System.Collections.Generic;

namespace WebApIGius.Models
{
    public partial class MunicipiosList
    {
        public MunicipiosList()
        {
            SitiosMain = new HashSet<SitiosMain>();
        }

        public short MunicipioNumero { get; set; }
        public string MunicipioNombre { get; set; }
        public string MunicipioProvinciaNombre { get; set; }
        public byte ProvinciaNumero { get; set; }
        public string ProvinciaNombre { get; set; }
        public byte RegionGeograficaNumero { get; set; }
        public DateTime SeguridadCuando { get; set; }
        public string SeguridadQuien { get; set; }
        public string SeguridadEstado { get; set; }
        public string SeguridadIpc { get; set; }

        public ICollection<SitiosMain> SitiosMain { get; set; }
    }
}

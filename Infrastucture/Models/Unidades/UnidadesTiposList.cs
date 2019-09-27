using System;
using System.Collections.Generic;

namespace WebApIGius.Models
{
    public partial class UnidadesTiposList
    {
        public UnidadesTiposList()
        {
            UnidadesMain = new HashSet<UnidadesMain>();
        }

        public short UnidadTipoNumero { get; set; }
        public string UnidadTipoDescripcion { get; set; }
        public string UnidadExplicacion { get; set; }
        public string UnidadTipoHeredar { get; set; }
        public string UnidadPublicar { get; set; }
        public string UnidadListar { get; set; }
        public string UnidadPrefijo { get; set; }
        public DateTime SeguridadCuando { get; set; }
        public string SeguridadQuien { get; set; }
        public string SeguridadEstado { get; set; }
        public string SeguridadIpc { get; set; }

        public ICollection<UnidadesMain> UnidadesMain { get; set; }
    }
}

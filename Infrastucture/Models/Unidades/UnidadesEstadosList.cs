using System;
using System.Collections.Generic;

namespace WebApIGius.Models
{
    public partial class UnidadesEstadosList
    {
        public UnidadesEstadosList()
        {
            UnidadesMain = new HashSet<UnidadesMain>();
        }

        public byte EstatoNumero { get; set; }
        public string EstatoClienteId { get; set; }
        public string EstatoDespcricion { get; set; }
        public string EstatoPublicar { get; set; }
        public string EstatoCuotas { get; set; }
        public DateTime SeguridadCuando { get; set; }
        public string SeguridadQuien { get; set; }
        public string SeguridadEstado { get; set; }
        public string SeguridadIpc { get; set; }

        public ICollection<UnidadesMain> UnidadesMain { get; set; }
    }
}

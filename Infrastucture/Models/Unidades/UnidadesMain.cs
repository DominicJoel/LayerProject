using System;
using System.Collections.Generic;

namespace WebApIGius.Models
{
    public partial class UnidadesMain
    {
        public int UnidadNumero { get; set; }
        public string UnidadClienteId { get; set; }
        public int SitioNumero { get; set; }
        public int AreaNumero { get; set; }
        public short UnidadTipoNumero { get; set; }
        public byte EstatoNumero { get; set; }
        public DateTime SeguridadCuando { get; set; }
        public string SeguridadQuien { get; set; }
        public string SeguridadEstado { get; set; }
        public string SeguridadIpc { get; set; }

        public UnidadesEstadosList EstatoNumeroNavigation { get; set; }
        public UnidadesTiposList UnidadTipoNumeroNavigation { get; set; }
    }
}

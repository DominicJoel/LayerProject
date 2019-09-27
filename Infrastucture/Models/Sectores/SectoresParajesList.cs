using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApIGius.Models
{
    public partial class SectoresParajesList
    {
        public SectoresParajesList()
        {
            SitiosMain = new HashSet<SitiosMain>();
        }

        public short SectorSecuencia { get; set; }

        public short MunicipioNumero { get; set; }

        public short SectorNumero { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SectorNombre { get; set; }
        public byte CiudadNumero { get; set; }
        public DateTime SeguridadCuando { get; set; }
        public string SeguridadQuien { get; set; }
        public string SeguridadEstado { get; set; }
        public string SeguridadIp { get; set; }

        public ICollection<SitiosMain> SitiosMain { get; set; }
    }
}

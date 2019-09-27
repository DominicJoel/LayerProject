using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApIGius.Models
{
    public partial class SitiosMain
    {
        public SitiosMain()
        {
            AreasList = new HashSet<AreasList>();
        }

        public int SitioNumero { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SitioClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int TipoNumero { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SitioNombre { get; set; }

        [MaxLength(3000, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SitioDescripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public short MunicipioDireccionNumero { get; set; }

        [MaxLength(1000, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SitioDireccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public short SectorSecuencia { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SitioDireccionProximo { get; set; }

        public decimal SitioDireccionLatitud { get; set; }

        public decimal SitioDireccionLongitud { get; set; }

        public string SitioTelefonoUno { get; set; }

        public string SitioTelefonoDos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EstadoNumero { get; set; }

        public DateTime SeguridadCuando { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadQuien { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SeguridadEstado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadIp { get; set; }

        public SitiosEstadosList EstadoNumeroNavigation { get; set; }
        public MunicipiosList MunicipioDireccionNumeroNavigation { get; set; }
        public SectoresParajesList SectorSecuenciaNavigation { get; set; }
        public SitiosTiposList TipoNumeroNavigation { get; set; }
        public ICollection<AreasList> AreasList { get; set; }
    }
}

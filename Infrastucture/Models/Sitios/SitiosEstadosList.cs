using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApIGius.Models
{
    public partial class SitiosEstadosList
    {
        public SitiosEstadosList()
        {
            SitiosMain = new HashSet<SitiosMain>();
        }

        public int EstadoNumero { get; set; }

        [MaxLength(8, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoCodigo { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoDespcricion { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoExplicacion { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoPublicar { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoListar { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string EstadoCriterio { get; set; }

        public DateTime SeguridadCuando { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadQuien { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SeguridadEstado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadIpc { get; set; }

        public ICollection<SitiosMain> SitiosMain { get; set; }
    }
}

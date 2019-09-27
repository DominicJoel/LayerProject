using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApIGius.Models
{
    public partial class SitiosTiposList
    {
        public SitiosTiposList()
        {
            SitiosMain = new HashSet<SitiosMain>();
        }


        public int TipoNumero { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoDespcricion { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoExplicacion { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoPublicar { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoListar { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoPrefijo { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoCriterio { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string TipoUnidad { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApIGius.Models
{
    public partial class AreasList
    {
        public int AreaNumero { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int SitioNumero { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string AreaClienteId { get; set; }

        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string AreaNombre { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string AreaObjetivo { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string AreaUnidades { get; set; }

        public decimal AreaLatitud { get; set; }

        public decimal AreaLongitud { get; set; }

        public DateTime SeguridadCuando { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadQuien { get; set; }

        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter.")]
        public string SeguridadEstado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SeguridadIp { get; set; }

        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
       // public int Linea { get; set; }
       // public int Ordenar { get; set; }

        public SitiosMain SitioNumeroNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApIGius.Models
{
    public partial class AreasFilterList
    {
        public int Area_Numero { get; set; }
        public int Sitio_Numero { get; set; }
        public string Area_Cliente_ID { get; set; }
        public string Area_Nombre { get; set; }
        public string Area_Objetivo { get; set; }
        public string Area_Unidades { get; set; }
        public decimal Area_Latitud { get; set; }
        public decimal Area_Longitud { get; set; }
        public DateTime Seguridad_Cuando { get; set; }
        public string Seguridad_Quien { get; set; }
        public string Seguridad_Estado { get; set; }
        public string Seguridad_Ip { get; set; }
        public int Linea { get; set; }
        public int Ultima_Linea { get; set; }
        public int Cantidad_Registros { get; set; }

    }
}

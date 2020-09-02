using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID.Models
{
    public class contacto
    {
        public int ID { get; set; }
        public string Nomina { get; set; }
        public string Fecha { get; set; }
        public string Evento { get; set; }
        public string Viaje { get; set; }
        public string Contacto { get; set; }
        public string FechaContacto { get; set; }
        public string Vive { get; set; }
        public string Convivencia { get; set; }
        public string LugarContagio { get; set; }
        public string FechaContagio { get; set; }
        public string Sintoma { get; set; }
        public string FechaSintoma { get; set; }
        public string EstadoSalud { get; set; }
        public string SintomasPrevalecen { get; set; }
        public string UltimoDiaLaboral { get; set; }
        public string ContactoLaboral { get; set; }
        public string Interaccion { get; set; }
        public string Areas { get; set; }
    }
}
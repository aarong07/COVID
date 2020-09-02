using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace COVID.Models
{
    public class trabajador
    {
        public string ID { get; set; }
        public string Nomina { get; set; }
        public string Nombre { get; set; }
        public string IdSitio { get; set; }
        public string IdArea { get; set; }
        public string IdProceso { get; set; }
        public string IdTurno { get; set; }
        public string Receta { get; set; }
        public string ComprobanteCOVID { get; set; }
        public string Telefono { get; set; }
        //[Range(35, 45, ErrorMessage ="El campo {0} de ser entre {1} y {2}")]
        public int Rango { get; set; }
        public int Estuveencontacto { get; set; }
        public int Dipositivo { get; set; }
        public int MDiario { get; set; }
        public int RegresarAlMonitoreo { get; set; }
        public int Vulnerable { get; set; }
        public int RegresarASospecha { get; set; }
        public int RegresarAPositivo { get; set; }


    }
}
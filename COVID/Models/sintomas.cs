using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID.Models
{
    public class sintomas
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Nomina { get; set; }
        public string Fecha { get; set; }
        public string IdMonitoreo { get; set; }
        public string Temperatura { get; set; }
        public string Fiebre37 { get; set; }
        public string Tosseca { get; set; }
        public string Cansancio { get; set; }
        public string MolestiasDolores { get; set; }
        public string DolorGarganta { get; set; }
        public string Diarrea { get; set; }
        public string Conjuntivitis { get; set; }
        public string DolorCabeza { get; set; }
        public string PerdidaSentidos { get; set; }
        public string ErupcionesCutaneasPerdidaColor { get; set; }
        public string DificultadRespirar { get; set; }
        public string DolorPecho { get; set; }
        public string IncapacidadHablarMoverse { get; set; }
        public string Oximetro { get; set; }
        public string Receta { get; set; }
        public string QRGUID{ get; set; }
        public string Escaneado { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID.Models
{
    public class sitio
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
    }
    public class area
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
    }
    public class proceso
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
    }
    public class turno
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
    }
    public class intesidad
    {
        public string ID { get; set; }
        public string Descripcion { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMonterrey.Models
{
    public class Persona
    {

        public String Dni { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Sexo { get; set; }
        public DateTime FechaNacimiento  { get; set; }
    }
}
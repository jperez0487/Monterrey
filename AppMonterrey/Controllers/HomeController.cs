using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppMonterrey.Models;
using System.Data.SqlClient;

namespace AppMonterrey.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<Persona> lista = null;
            //Demo 02

            //DEmo0334

            var sConexion = "Server=JPEREZ;Database=Monterrey;Trusted_Connection=True;";
            using (cn = new SqlConnection(sConexion)) {
                using (cmd = new SqlCommand()) {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Persona";
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                    Persona persona = null;
                    lista = new List<Persona>();
                    while (dr.Read()) {
                        int posDni = dr.GetOrdinal("DNI");
                        int posNombre= dr.GetOrdinal("NOMBRE");
                        int posApellidos = dr.GetOrdinal("APELLIDOS");
                        int posDireccion = dr.GetOrdinal("DIRECCION");
                        int posSexo = dr.GetOrdinal("SEXO");
                        int posFechaNacimiento = dr.GetOrdinal("FECHA_NACIMIENTO");

                        persona = new Persona
                        {
                            Dni = dr.GetString(posDni),
                            Nombre = dr.GetString(posNombre),
                            Apellidos = dr.GetString(posApellidos),
                            Direccion = dr.GetString(posDireccion),
                            Sexo = dr.GetString(posSexo),
                            FechaNacimiento = dr.GetDateTime(posFechaNacimiento)
                        };
                        
                        lista.Add(persona);
                    }
                }
            }
            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
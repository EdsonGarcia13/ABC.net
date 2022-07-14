using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace prueba.Models
{
    public class UsuarioModel
    {
        public string Nombre { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fecha_de_Nacimiento { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string CodigoPostal { get; set; }
        public string Correo { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }        
        public int PersonId { get; set; }
        
    }
}
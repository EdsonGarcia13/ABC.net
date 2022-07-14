using System;
using Newtonsoft.Json;
using prueba.LogicaDatos;
using prueba.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace prueba.LogicaDatos
{
    public class Logica
    {
        public static DataTable GuardarUsuarios(UsuarioModel model)
        {
            return Catalogos.GuardarUsuarios(model);
        }

        public static DataTable ObtenerUsuarios(UsuarioModel model)
        {
            return Catalogos.ObtenerUsuarios(model);
        }

        public static DataTable editarUsuarios(UsuarioModel model)
        {
            return Catalogos.editarUsuarios(model);
        }
        public static DataTable eliminarUsuarios(UsuarioModel model)
        {
            return Catalogos.eliminarUsuarios(model);
        }
    }
}
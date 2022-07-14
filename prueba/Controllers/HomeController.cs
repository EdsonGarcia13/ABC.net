using Newtonsoft.Json;
using prueba.LogicaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using System.Web.Script.Serialization;

namespace prueba.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GuardarUsuarios(UsuarioModel modelo)
        {
            List<UsuarioModel> model = new List<UsuarioModel>();
            DataTable dt = Logica.GuardarUsuarios(modelo);
            if (dt != null && dt.Rows.Count > 0)
            {
                model = JsonConvert.DeserializeObject<List<UsuarioModel>>(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1000000000;
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1000000000;
            ViewBag.json = "";
            return json;
        }
        public ActionResult Usuarios()
        {
            return View();
        }



        //[HttpPost("ObtenerUsuarios")]
        //public string LeerNombre(int id)
        //{
        //    return id switch
        //    {
        //        1 => "Net",
        //        2 => "mentor",
        //        _ => throw new System.NotImplementedException()
        //    };
        //}

        public ActionResult ObtenerUsuarios(UsuarioModel modelo)

        {
            List<UsuarioModel> model = new List<UsuarioModel>();
            DataTable dt = Logica.ObtenerUsuarios(modelo);
            if (dt != null && dt.Rows.Count > 0)
            {
                model = JsonConvert.DeserializeObject<List<UsuarioModel>>(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1000000000;
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1000000000;
            ViewBag.json = "";
            return json;
        }


        
        public ActionResult editarUsuarios()
        {
            return View();
        }

        public ActionResult editandoUsuarios(UsuarioModel modelo)
        {
            List<UsuarioModel> model = new List<UsuarioModel>();
            DataTable dt = Logica.editarUsuarios(modelo);
            if (dt != null && dt.Rows.Count > 0)
            {
                model = JsonConvert.DeserializeObject<List<UsuarioModel>>(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1000000000;
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1000000000;
            ViewBag.json = "";
            return json;
        }

        public ActionResult eliminarUsuarios(UsuarioModel modelo)
        {
            List<UsuarioModel> model = new List<UsuarioModel>();
            DataTable dt = Logica.eliminarUsuarios(modelo);
            if (dt != null && dt.Rows.Count > 0)
            {
                model = JsonConvert.DeserializeObject<List<UsuarioModel>>(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1000000000;
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1000000000;
            ViewBag.json = "";
            return json;
        }









        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

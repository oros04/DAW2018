using MSoro_AragonSkills.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MSoro_AragonSkills.Controllers
{
    public class HomeController : Controller
    {
        PeliculasBDEntities bd = new PeliculasBDEntities();

        public ActionResult Index()
        {
            
            return View(bd.Peliculas.ToList());
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
        public ActionResult Ficha(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas pelicula = bd.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.url_imagen = "https://" + pelicula.url_foto;
            ViewBag.url_pelicula = "https://www.imdb.com/"+pelicula.url_imbd;
            ViewBag.idPelicula = new SelectList(bd.Peliculas, "idPelicula", "nombre", pelicula.idPelicula);
            return View(pelicula);
        }

        // POST:
        // Para protegerse de ataques de publicación excesiva
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Ficha([Bind(Include = "idPelicula,nombre,rating,posicion,reparto,voto,año,url_foto,url_imbd")] Peliculas pelicula)
        {
            
                if (ModelState.IsValid)
                {
                    bd.Entry(pelicula).State = EntityState.Modified;
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.idPelicula = new SelectList(bd.Peliculas, "idPelicula", "nombre", pelicula.idPelicula);
                return View(pelicula);
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (@ViewBag.Eliminar==true) {
                Peliculas pelicula = bd.Peliculas.Find(id);
                bd.Peliculas.Remove(pelicula);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var keyValue = string.Format("{0}:{1}", Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                isValidName = true;
            }

            return isValidName;
        }
    }
}
using MSoro.AragonSkills.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            ViewBag.idPelicula = new SelectList(bd.Peliculas, "idPelicula", "nombre", pelicula.idPelicula);
            return View(pelicula);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPelicula,nombre,rating,posicion,reparto,voto,año,url_foto,url_imbd")] Peliculas pelicula)
        {
            if (ModelState.IsValid)
            {
                bd.Entry(pelicula).State = EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idordenador = new SelectList(bd.Peliculas, "idPelicula", "nombre", pelicula.idPelicula);
            return View(pelicula);
        }
    }
}
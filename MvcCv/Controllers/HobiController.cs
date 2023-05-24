using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        // GET: Egitim
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            repo.Tdelete(hobi);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult HobiDuzenle(TblHobilerim t)
        {
            var hobiler = repo.Find(x => x.ID == t.ID);
            hobiler.Aciklama1 = t.Aciklama1;
            hobiler.Aciklama2 = t.Aciklama2;
            repo.TUpdate(hobiler);
            return RedirectToAction("Index");
        }
    }
}
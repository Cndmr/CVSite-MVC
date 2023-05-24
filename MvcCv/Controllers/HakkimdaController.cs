using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvEntities db=new DbCvEntities();
        GenericRepository<TblHakkinda> repo = new GenericRepository<TblHakkinda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkinda p)
        {
            var t = repo.Find(x=>x.ID==1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Teleon = p.Teleon;
            t.Aciklama = p.Aciklama;
            t.Resim=p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
            
        }

    }
}
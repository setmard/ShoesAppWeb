using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;
using ShoesData;

namespace MVCCrud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index(string searchString)
        {
            //string searchString = id;
            List<ListTablaViewModel> lst;
            using (DataProductsEntities db = new DataProductsEntities())
            {
                lst = (from d in db.Products
                           select new ListTablaViewModel
                           {
                               Id = d.Id,
                               IdType = d.IdType,
                               IdBrand = d.IdBrand,
                               IdCatalog =d.IdCatalog,
                               IdProvider = d.IdProvider,
                               IdColor = d.IdColor,
                               Title = d.Title,
                               Nombre =d.Nombre,
                               Description =d.Description,
                               Observations =d.Observations,
                               PriceDistributor =d.PriceDistributor,
                               PriceClient = d.PriceClient,
                               PriceMember = d.PriceMember,
                               IsEnabled = d.IsEnabled,
                               Keywords = d.Keywords,
                               DateUpdate = d.DateUpdate
                              
                               
             
                           }).ToList();

                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    lst = lst.Where(s => s.Nombre.Contains(searchString)).ToList();
                //}
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                lst = lst.Where(s => s.Nombre.Contains(searchString)).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DataProductsEntities db = new DataProductsEntities())
                    {
                        var oTabla = new Products();
                        oTabla.IdType = model.IdType;
                        oTabla.IdColor = model.IdColor;
                        oTabla.IdBrand = model.IdBrand;
                        oTabla.IdProvider = model.IdProvider;
                        oTabla.IdCatalog = model.IdCatalog;
                        oTabla.Title = model.Title;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Description = model.Description;
                        oTabla.Observations = model.Observations;
                        oTabla.PriceClient = model.PriceClient;
                        oTabla.Keywords = model.Keywords;
                        oTabla.DateUpdate = model.DateTime;
                        db.Products.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DataProductsEntities db = new DataProductsEntities())
            {
                var oTabla = db.Products.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Title = oTabla.Title;
                model.Description = oTabla.Description;
                model.Observations = oTabla.Observations;
                model.PriceClient = oTabla.PriceClient;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DataProductsEntities db = new DataProductsEntities())
                    {
                        var oTabla = db.Products.Find(model.Id);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Title = model.Title;
                        oTabla.Description = model.Description;
                        oTabla.Observations = model.Observations;
                        model.PriceClient = model.PriceClient;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (DataProductsEntities db = new DataProductsEntities())
            {
              
                var oTabla = db.Products.Find(Id);
                db.Products.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }

    }
}
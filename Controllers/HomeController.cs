using machine_test2.DAL;
using machine_test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace machine_test2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            CategoryDal catdal = new CategoryDal();
            List<Categories> catlist = catdal.CategoriesList();

            ProductDal dal = new ProductDal();
            List<Products> list = dal.ProductList();
            ViewBag.catlist = catlist;
            ViewBag.pageCount = dal.ProductCount().Count;
            return View(list);
        }

        [HttpPost]
        public JsonResult Insert(Products product)
        {
            ProductDal dal = new ProductDal();
            int status = dal.insert(product);
            return Json(status, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult Update(Products product)
        {
            ProductDal dal = new ProductDal();
            int status = dal.update(product);
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Delete(Products product)
        {
            ProductDal dal = new ProductDal();
            int status = dal.delete(product.id);
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Pagination(string pageNo)
        {
            ProductDal dal = new ProductDal();

            return Json(dal.Pagination(pageNo), JsonRequestBehavior.AllowGet);
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
using machine_test2.DAL;
using machine_test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace machine_test2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryDal dal = new CategoryDal();
            List<Categories> list = dal.CategoriesList();
            return View(list);
        }


        [HttpPost]
        public JsonResult Insert(Categories cat)
        {
            CategoryDal dal = new CategoryDal();
            int status = dal.insert(cat);
            return Json(status, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult Update(Categories cat)
        {
            CategoryDal dal = new CategoryDal();
            int status = dal.update(cat);
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Delete(Categories cat)
        {
            CategoryDal dal = new CategoryDal();
            int status = dal.delete(cat.id);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
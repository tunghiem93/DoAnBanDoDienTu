using OA.DAL.Category;
using OA.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OA.PHONE.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDAL categoryDAL;
        public CategoryController()
        {
            categoryDAL = new CategoryDAL();
        }
        public async Task<ActionResult> Index()
        {
            var models = await categoryDAL.GetList();
            return View(models);
        }

        public ActionResult New()
        {
            return View(new CategoryDTO());
        }

        [HttpPost]
        public async Task<ActionResult> New(CategoryDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await categoryDAL.Create(model);
            if(result)
            {
                TempData["MessagesSuccessful"] = "Tạo thể loại sản phẩm thành công";
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            TempData["MessagesError"] = "Tạo thể loại sản phẩm không thành công";
            return View(model);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            var model = await categoryDAL.GetById(Id);
            if (model == null)
                model = new CategoryDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var (result, msg) = await categoryDAL.Update(model);
            if (result)
            {
                TempData["MessagesSuccessful"] = msg;
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            TempData["MessagesError"] = msg;
            return View(model);
        }

        public async Task<ActionResult> Destroy(int Id)
        {
            var (result, msg) = await categoryDAL.Destroy(Id);
            if (result)
            {
                return Json(new { success = true, message = msg }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = msg }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")] // bu kısma gelen  kullanılcaların areadan geldiğini bildirmiş olduk. Klasör ismi verilir.
                    //oluşturuldan sonra Startup Dosyasında tanımlanması gerekir.
    public class CategoryController : Controller
    {
        

        //Pagination =Sayfalama İşlemi yapacağız. indirilecek paketler x.pagedlist,x.pagedlist.mvc.core 

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p); //p den gelen değerleri validasyon sınfından kontrolünü sağla demek. 
            if (result.IsValid)
            {
                //ekleme işlemi yapılırken httpget ve httppost attributelerinin tanımlandığı  metotların isimleri aynı olmak zorundadır. 
                //httpget sayfa yüklenirken 
                //submit olayınd a post işlemi çalısır. 
                // Httpget attrubte komutu sayfada kategorize veya benzeri işlemler kullanılırken sayfa yüklendiği anda listlelenmesi isteenn niteliklerde kullanılabilir. 
               
                p.CategoryStatus = true;             
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public IActionResult DeleteCategory(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }

}

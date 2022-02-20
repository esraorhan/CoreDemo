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

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p); //p den gelen değerleri validasyon sınfından kontrolünü sağla demek. 
            if (result.IsValid)
            {
                //ekleme işlemi yapılırken httpget ve httppost attributelerinin tanımlandığı  metotların isimleri aynı olmak zorundadır. 
                //httpget sayfa yüklenirken 
                //submit olayınd a post işlemi çalısır. 
                // Httpget attrubte komutu sayfada kategorize veya benzeri işlemler kullanılırken sayfa yüklendiği anda listlelenmesi isteenn niteliklerde kullanılabilir. 
                //ÖDEV -şEHİR VE İLÇELERİ GETİR DROPDAOWN vİEWMODEL İLE ....
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
           
        }
    }
}

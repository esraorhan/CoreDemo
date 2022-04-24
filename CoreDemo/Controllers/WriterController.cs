using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreDemo.Controllers
{
    //[Authorize]  => config de proje bazlı authorize işlemi yapmış olduk. startup. cs de tamamn
    public class WriterController : Controller
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult WriterEditProfile()
        {
            var writervalues = vm.TGetById(1);
            return View(writervalues);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult WriterEditProfile(Writer p,string AgainPassword)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                if (p.WriterPassword == AgainPassword)
                {
                    vm.TUpdate(p);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Hata = "Şifreler Uyumsuz kontrol ediniz.";
                    //return RedirectToAction("WriterEditProfile", "Writer");
                }
               
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(Writer p)
        {
            vm.TAdd(p);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

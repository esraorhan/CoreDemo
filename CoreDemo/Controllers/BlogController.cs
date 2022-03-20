﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }


        public IActionResult BlogListByWriter()
        {
           var values= bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryList = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text= x.CategoryName,
                                                     Value =x.CategoryID.ToString()

                                                 }).ToList();
            ViewBag.cv = categoryList;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p); //p den gelen değerleri validasyon sınfından kontrolünü sağla demek. 
            if (result.IsValid)
            {
                //ekleme işlemi yapılırken httpget ve httppost attributelerinin tanımlandığı  metotların isimleri aynı olmak zorundadır. 
                //httpget sayfa yüklenirken 
                //submit olayınd a post işlemi çalısır. 
                // Httpget attrubte komutu sayfada kategorize veya benzeri işlemler kullanılırken sayfa yüklendiği anda listlelenmesi isteenn niteliklerde kullanılabilir. 
                //ÖDEV -şEHİR VE İLÇELERİ GETİR DROPDAOWN vİEWMODEL İLE ....
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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
    }
}

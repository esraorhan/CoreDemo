using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}

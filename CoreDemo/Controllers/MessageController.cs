using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        //mesajların tamamını göstermk için açıldı.
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 3;

            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }

       
        public IActionResult MessageDetails(int id)
        {
            var messagevalue = mm.TGetById(id);
            return View(messagevalue);
        }
    }
}

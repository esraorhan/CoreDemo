using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")] //bildirmek gerekiyor..
    public class BlogController : Controller
    {
        //ClosedXml paketini kurduk..
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;// 1 satıra başlık belirledik.
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName ;
                    BlogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet","CshapileExcel.xlsx");
                }
            }
           // return View();
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel{ID=2,BlogName="Test Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2022 Olimpiyatları"}
            };

            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }


        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;// 1 satıra başlık belirledik.
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "CshapileExcel.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> blogs = new List<BlogModel2>();

            using(var c = new Context())
            {
                blogs = c.Blogs.Select(c => new BlogModel2 { ID = c.BlogID, BlogName = c.BlogTitle }).ToList();
            }
            return blogs;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}

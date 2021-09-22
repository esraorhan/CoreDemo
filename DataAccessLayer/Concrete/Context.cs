﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext //db bağlantı sınıfı
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //connecting string tanımlanacak yer...
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-8AK4CAP;database=CoreBlogDb; integrated security= true;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }
}
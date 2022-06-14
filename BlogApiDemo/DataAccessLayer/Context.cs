using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //connecting string tanımlanacak yer...
        {
            //  optionsBuilder.UseSqlServer("server=DESKTOP-8AK4CAP;database=CoreBlogDb; integrated security= true;");
            optionsBuilder.UseSqlServer("server=ESRAORHAN;database=CoreBlogApiDb; integrated security= true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

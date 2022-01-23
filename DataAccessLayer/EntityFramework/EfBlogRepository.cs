using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using(var c = new Context())
            { 
                //beraberinde ilişkili olduğu tabloyu da getirmesini istedik.
                //ilk önce abstract klosörğnde list olarak metot tanımlandı önceki adım..
                //daha sonrasında repositories klasöründe blogrepository sildik.çünkü generic kullanmaya başladık.
                return c.Blogs.Include(x => x.Category).ToList();
            }
           
        }
    }
}

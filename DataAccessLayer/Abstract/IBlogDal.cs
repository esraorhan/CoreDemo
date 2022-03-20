using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IBlogDal : IGenericDal<Blog> // İnclude işlem için kullandık.
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id); //yazara göre bilgilerin getirmesi için yazdık.
    }
}

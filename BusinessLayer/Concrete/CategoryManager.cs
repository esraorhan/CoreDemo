using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Business katmanında abctract klosörü içinde yer alan interfaceler : Service olarak adlandırılıyor...
        //Business katmanında yer alan Concrete klasörü içinde yer alaan sınıflar : Manager olarak adlandırılıyor...
        //Business katmanı içerisinde yapılmak istenen : Validasyon = Geçerlilik kuralları 
        //EfCategoryRepository efCategoryRepository;
        ICategoryDal _categoryDal;
   
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
    }
}

﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList(); //set e bağlı olark kullanıyoruz. entiti sınıfını dışarıdan alabilmek için böyle bir yöntem kullandık 

        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
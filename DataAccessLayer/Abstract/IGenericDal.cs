using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal <T> where  T : class
    {
        //Generic amacı : genel bir Crud yazmaya çalışmak her clas için oluşturmak yerine dinamik yapmış olduk .
        //bundan dolayı blog ve gateriden silip kalıtım aldık...
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        List<T> GetListAll();
        T GetByID(int id);

        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}

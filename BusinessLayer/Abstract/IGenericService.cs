using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {

        //busineslayer içinde yazmıs oldugumuz servisde daha önce her tablonun service yazmıştık bunu en tek bir kere yazıp her yerde kullanmak 
        //için bu yapıyı en genel hale getirmiş olduk. 
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetList();
        T TGetById(int id);
    }
}

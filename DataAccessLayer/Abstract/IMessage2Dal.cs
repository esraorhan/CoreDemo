using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Messaage2>
    {
        List<Messaage2> GetListWithMessageByWriter(int id);
    }
}

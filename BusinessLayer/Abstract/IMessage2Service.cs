using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Messaage2>
    {
        List<Messaage2> GetInboxListByWriter(int id);
        List<Messaage2> GetSendBoxListByWriter(int id);


    }
}

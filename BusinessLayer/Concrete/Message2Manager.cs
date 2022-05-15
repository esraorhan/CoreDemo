using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Messaage2> GetInboxListByWriter(int id) 
        {
            return _message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Messaage2> GetList()
        {
            return _message2Dal.GetListAll();
        }

        public void TAdd(Messaage2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Messaage2 t)
        {
            throw new NotImplementedException();
        }

        public Messaage2 TGetById(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public void TUpdate(Messaage2 t)
        {
            throw new NotImplementedException();
        }
    }
}

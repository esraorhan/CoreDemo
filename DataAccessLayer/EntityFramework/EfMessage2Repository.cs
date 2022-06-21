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
   public class EfMessage2Repository : GenericRepository<Messaage2>, IMessage2Dal
    {
        //public List<Messaage2> GetInboxWithMessageByWriter(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Messaage2> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {              //alıcı için yapılan include etme işlemi
                return c.Messaage2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }

        public List<Messaage2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var c = new Context()) //bizim gönderdiğimiz mesajlar listelenmesi için 
            {
                return c.Messaage2s.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }
    }
}

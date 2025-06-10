using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p); 
        List<Message> GetListSendbox(string p);
        void MessageAddBL(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}

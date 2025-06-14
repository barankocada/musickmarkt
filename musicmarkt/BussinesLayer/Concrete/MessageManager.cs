﻿using BussinesLayer.Abstaract1;
using DataAccessLayer.Abstract;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
           return _messagedal.Get(x=>x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagedal.List(x => x.ReciverMail == p);
        }
       
        public List<Message> GetListSendbox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p);
        }

        public void MessageAddBL(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}

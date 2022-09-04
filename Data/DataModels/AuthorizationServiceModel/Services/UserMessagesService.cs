using ApplicationDb.Entities;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class UserMessagesService
{
    public UserMessagesService( ) 
    {
    }

    public int Send(UserMessage message, int fromUserIID, int toUserId)
    {
        var _authorization = AppProviderService.GetInstance().Get<AuthorizationDataModel>();
        message.FromUserID = _authorization.Users.Find(fromUserIID).ID;
        //message.ToUser = _context.Users.Find(toUserId);
        //_context.Messages.Add(message);
        return _authorization.SaveChanges();
    }

    /*public List<UserMessage> GetInbox()
    {
        return _authorization.IsSignin()? this.GetInbox(_authorization.Verify().ID): new List<UserMessage>();
    }*/
    public List<UserMessage> GetOutbox()
    {

        var _authorization = AppProviderService.GetInstance().Get<AuthorizationService>();

        return _authorization.IsSignin() ? this.GetOutbox(_authorization.Verify().ID) : new List<UserMessage>();
    }
   
    /*  public List<UserMessage> GetInbox(int userId)
      {
          return (from p in _context.Messages where p.ToUser.ID == userId select p).ToList();
      }*/

    public List<UserMessage> GetOutbox(int userId)
    {
        var _context = AppProviderService.GetInstance().Get<AuthorizationDataModel>();

        return (from p in _context.Messages.Include(m => m.FromUser) where p.FromUser.ID == userId select p).ToList();
    }

  
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Email.util;

namespace WickedTunaAPI.Email.Service
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}

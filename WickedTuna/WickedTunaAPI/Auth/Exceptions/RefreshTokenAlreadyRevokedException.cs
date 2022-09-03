using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WickedTunaAPI.Auth.Exceptions
{
    public class RefreshTokenAlreadyRevokedException : Exception
    {
        public RefreshTokenAlreadyRevokedException()
        {
        }
    }
}

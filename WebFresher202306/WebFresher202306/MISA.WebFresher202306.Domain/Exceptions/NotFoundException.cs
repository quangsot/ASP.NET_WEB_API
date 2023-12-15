using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    public class NotFoundException : ResponseException
    {
        public NotFoundException(ErrorCode errorCode, string userMessage) : base(errorCode, userMessage){}
    }
}

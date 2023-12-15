using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// lỗi đầu vào của người dùng
    /// </summary>
    /// author: Trương Mạnh Quang (24/8/2023)
    public class BadRequestException : ResponseException
    {
        public BadRequestException(ErrorCode errorCode, string userMessage) : base(errorCode, userMessage)
        {
        }
    }
}

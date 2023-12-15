using System.Net;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// đối tượng thông báo lỗi
    /// author: Trương Mạnh Quang (4/8/2023)
    /// </summary>
    public class ResponseException : Exception
    {
        #region Properties
        /// <summary>
        /// Mã lỗi nội bộ.
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// thông báo lỗi của user.
        /// author: Trương Mạnh Quang (6/8/2023)
        /// </summary>
        public string? UserMessage { get; set; }

        #endregion
        #region Contructor
        /// <summary>
        /// hàm khỏi tạo không đối số.
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        public ResponseException() {}
        /// <summary>
        /// hàm khởi tạo với đối số: mã lỗi request, thông báo của user, thông báo của dev.
        /// author: Trương Mạnh Quang (6/8/2023)
        /// </summary>
        /// <param name="statusCodeError">mã lỗi request</param>
        /// <param name="userMessage">thông báo lỗi của user</param>
        /// <param name="devMessage">thông báo lỗi của dev</param>
        public ResponseException(ErrorCode errorCode, string userMessage)
        {
            ErrorCode = errorCode;
            UserMessage = userMessage;
        }
        #endregion
    }
}

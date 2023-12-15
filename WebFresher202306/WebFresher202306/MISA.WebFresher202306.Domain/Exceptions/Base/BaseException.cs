using System.Text.Json;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// đối tượng ngoại lệ cơ bản
    /// </summary>
    public class BaseException
    {
        #region Properties
        /// <summary>
        /// mã lỗi
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        public ErrorCode ErrorCode { get; set; }
        /// <summary>
        /// thông báo cho dev
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        public string? DevMessage { get; set; }
        /// <summary>
        /// thông báo cho người dùng
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        public List<string>? UserMessage { get; set; }
        /// <summary>
        /// mã trace
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        public string? TraceId { get; set; }
        /// <summary>
        /// thông tin thêm
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        public string? MoreInfo { get; set; }
        #endregion

        #region Contructor
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public BaseException() {
            UserMessage = new List<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// hàm ghi đề hàm có sẵn ToString()
        /// author: Trương Mạnh Quang (2/8/2023)
        /// </summary>
        /// <returns>chuỗi json</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion

    }
}

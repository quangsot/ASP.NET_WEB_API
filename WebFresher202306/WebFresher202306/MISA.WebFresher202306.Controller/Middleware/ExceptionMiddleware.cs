using Microsoft.AspNetCore.Http;
using System.Net;
using WebFresher202306.Domain;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebFresher202306.Domain.Resource;

namespace WebFresher202306.Controller
{
    /// <summary>
    /// middleware xử lý ngoại lệ
    /// author: Trương Mạnh Quang (2/8/2023)
    /// </summary>
    public class ExceptionMilddleware
    {
        #region Properties
        /// <summary>
        /// đối tượng delegate tham chiếu đến các phương thức xử lý request
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        private readonly RequestDelegate _next;
        #endregion
        #region Constructer
        /// <summary>
        /// hàm khởi tạo gọi đến phương thức tiếp theo
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMilddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// hàm thực thi middleware và bắt ngoại lệ
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // thành công
                await _next(context);
            }
            catch (ResponseException ex)
            {
                // ngoại lệ cho người dùng
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                // ngoại lệ do hệ thống
                Console.WriteLine("============================");
                Console.WriteLine(ex);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var listUserMsg = new List<string>() { $"{MISAResource.ResourceManager.GetString("InternalServerErrorMessage")}" };
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = ErrorCode.NoError,
                    UserMessage = listUserMsg,
                    DevMessage = ex.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = ex.HelpLink
                }.ToString() ?? "");
            }
        }
        /// <summary>
        /// hàm xử lý lỗi
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        /// <param name="context">đối tượng http</param>
        /// <param name="ex">ngoại lệ</param>
        /// <returns>Task base exception</returns>
        private static async Task HandleExceptionAsync(HttpContext context, ResponseException ex)
        {
            Console.WriteLine(ex);
            context.Response.ContentType = "application/json";
            switch (ex)
            {
                case BadRequestException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await ResponseBaseException(context, ex);
                    break;
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await ResponseBaseException(context, ex);
                    break;
                case NoContentException:
                    context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                    await ResponseBaseException(context, ex);
                    break;
                case ConflictException:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    await ResponseBaseException(context, ex);
                    break;
            }
        }

        /// <summary>
        /// hàm khởi tạo và trả về lỗi cho người dùng
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (4/8/2023)
        private static async Task ResponseBaseException(HttpContext context, ResponseException ex)
        {
            var listUserMsg = new List<string>() { ex.UserMessage ?? "" };
            await context.Response.WriteAsync(text: new BaseException()
            {
                ErrorCode = ex.ErrorCode,
                UserMessage = listUserMsg,
                DevMessage = ex.Message,
                TraceId = context.TraceIdentifier,
                MoreInfo = ex.HelpLink
            }.ToString() ?? "");
            return;
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using WebFresher202306.Application;

namespace WebFresher202306.Controllers
{
    [ApiController]
    public abstract class ReadOnlyController<TEntityDTO, TKey> : ControllerBase
        where TEntityDTO : class
    {
        public readonly IReadOnlyService<TEntityDTO, TKey> _readOnlyService;

        protected ReadOnlyController(IReadOnlyService<TEntityDTO, TKey> readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        /// <summary>
        /// hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _readOnlyService.GetAllAsync();

            return Ok(result);
        }

        /// <summary>
        /// hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] TKey id)
        {
            var result = await _readOnlyService.GetByIdAsync(id);

            return Ok(result);
        }


    }
}

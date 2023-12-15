using Microsoft.AspNetCore.Mvc;
using WebFresher202306.Application;

namespace WebFresher202306.Controllers
{
    [ApiController]
    public class CrudController<TEntityDTO, TKey, TEntityCreateDTO, TEntityUpdateDTO> 
        : ReadOnlyController<TEntityDTO, TKey>
        where TEntityDTO : class
        where TEntityCreateDTO : class
        where TEntityUpdateDTO : class
    {
        public readonly ICrudService<TEntityDTO, TKey, TEntityCreateDTO, TEntityUpdateDTO> _crudService;

        public CrudController(ICrudService<TEntityDTO, TKey, TEntityCreateDTO, TEntityUpdateDTO> crudService) : base(crudService)
        {
            _crudService = crudService;
        }

        /// <summary>
        /// hàm thêm
        /// </summary>
        /// <param name="employeeCreate"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TEntityCreateDTO employeeCreate)
        {
            var result = await _crudService.CreateAsync(employeeCreate);

            return StatusCode(statusCode: 201, result);
        }

        /// <summary>
        /// hàm cập nhật
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] TKey id, [FromBody] TEntityUpdateDTO employeeUpdate)
        {
            var result = await _crudService.UpdateAsync(id,employeeUpdate);
            
            return Ok(result);
        }

        /// <summary>
        /// hàm xóa 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] TKey id)
        {
            var result = await _crudService.DeleteAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteManyAsync([FromBody] List<TKey> ids)
        {
            var result = await _crudService.DeleteManyAsync(ids);

            return Ok(result);
        }
    }
}

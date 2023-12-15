using Microsoft.AspNetCore.Mvc;
using WebFresher202306.Application;

namespace WebFresher202306.Controllers
{
    /// <summary>
    /// author: Trương Mạnh Quang (9/8/2023)
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PositionController : ReadOnlyController<PositionDTO, Guid>
    {
        private readonly IPositionService _positionService;
        public PositionController( IPositionService positionService) : base(positionService)
        {
            _positionService = positionService;
        }
    }
}

using AutoMapper;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{

    public class PositionService : ReadOnlyService<Position, PositionDTO, Guid>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepository positionRepository, IMapper mapper) : base(positionRepository)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public override PositionDTO MapTEntityToTEntityDto(Position entity)
        {
            var entityDTO = _mapper.Map<Position, PositionDTO>(entity);
            return entityDTO;
        }
    }
}

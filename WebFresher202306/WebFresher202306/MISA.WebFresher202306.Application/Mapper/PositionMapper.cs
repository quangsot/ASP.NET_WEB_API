using AutoMapper;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class PositionMapper : Profile
    {
        public PositionMapper()
        {
            CreateMap<PositionCreate, Position>().ReverseMap();
            CreateMap<PositionUpdate, Position>().ReverseMap();

            CreateMap<Position, PositionDTO>().ReverseMap();
        }
    }
}

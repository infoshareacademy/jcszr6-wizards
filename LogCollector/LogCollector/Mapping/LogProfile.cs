using AutoMapper;
using LogCollector.Dto;
using LogCollector.Models;

namespace LogCollector.Mapping
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDto>()
                .ReverseMap();
        }
    }
}

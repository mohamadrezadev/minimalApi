using AutoMapper;
using MyAPi.Dtos;
using MyAPi.Models;

namespace MyAPi.Profiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            //Source => Target
            CreateMap<Command,CommandReadDto>();
            CreateMap<CommandCreateDto,Command>();
            CreateMap<CommandUpdateDto,Command>();
        }
    }
}
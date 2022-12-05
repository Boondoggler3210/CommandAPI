using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommangeAPI.Profiles;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto, Command>();
    }
}
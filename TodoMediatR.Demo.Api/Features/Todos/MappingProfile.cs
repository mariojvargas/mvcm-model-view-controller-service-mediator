using System;
using AutoMapper;
using TodoApiMediatR.Demo.Api.Infrastructure.Data;

namespace TodoApiMediatR.Demo.Api.Features.Todos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoListItemDto>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Name))
                .ForMember(destination => destination.IsComplete, options => options.MapFrom(source => source.IsComplete))
                ;
        }
    }
}

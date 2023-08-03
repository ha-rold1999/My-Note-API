using AutoMapper;
using My_Note_API.EntityFramwork.ToDoEntityFramework;

namespace My_Note_API
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ToDo, Archive_ToDo>()
                .ForMember(dest => dest.ToDo_Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ToDo_Goal, opt => opt.MapFrom(src => src.Goal))
                .ForMember(dest => dest.Archived_Date, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ToDo, ToDo>();
        }
    }
}

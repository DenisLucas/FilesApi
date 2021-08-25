
using AutoMapper;
using File.Domain.Entities;
using File.Domain.ViewModel;

namespace File.Domain.Mappers
{
    public class ViewModelFilesMapper : Profile
    {
        public ViewModelFilesMapper()
        {
            CreateMap<Files,ViewModelFiles>(); 
            CreateMap<ViewModelFiles, Files>();
            
        }
    }
}

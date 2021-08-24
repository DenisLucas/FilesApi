using System;
using AutoMapper;
using File.Core.File.Command;
using File.Domain.Entities;
using File.Domain.ModelVIews;

namespace File.Core.Maps.File
{
    public class ModelViewFilesMapper : Profile
    {
        public ModelViewFilesMapper()
        {
            CreateMap<Files,ModelViewFiles>(); 
            CreateMap<ModelViewFiles, Files>();
        }
    }
}

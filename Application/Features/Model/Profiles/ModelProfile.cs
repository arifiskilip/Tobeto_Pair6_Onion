using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class ModelProfile : Profile
	{
        public ModelProfile()
        {
            CreateMap<Model, AddModelCommand>().ReverseMap();
            CreateMap<Model, AddModelResponse>().ReverseMap();
            CreateMap<Model, GetByIdModelResponse>().ReverseMap();
			CreateMap<Model, UpdateModelResponse>().ReverseMap();
			CreateMap<Model, UpdateModelCommand>().ReverseMap();
		}
    }
}

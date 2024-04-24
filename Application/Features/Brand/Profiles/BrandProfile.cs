using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class BrandProfile : Profile
	{
        public BrandProfile()
        {
            CreateMap<Brand, AddBrandCommand>().ReverseMap();
            CreateMap<Brand,AddBrandResponse>()
                .ForMember(b=> b.ModelName, opt=>opt.MapFrom(src=>src.Model.Name));


			CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
			CreateMap<Brand, UpdateBrandResponse>()
				.ForMember(b => b.ModelName, opt => opt.MapFrom(src => src.Model.Name));


			CreateMap<Brand, GetByIdBrandCommand>().ReverseMap();
			CreateMap<Brand, GetByIdBrandResponse>()
				.ForMember(b => b.ModelName, opt => opt.MapFrom(src => src.Model.Name));
		}
    }
}

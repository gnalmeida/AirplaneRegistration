using Airplane.Application.ViewModels;
using AutoMapper;

namespace Airplane.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<Domain.Entities.Airplane, AirplaneViewModel>();
		}
	}
}

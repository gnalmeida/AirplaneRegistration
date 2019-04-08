using Airplane.Application.ViewModels;
using Airplane.Domain.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Application.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<AirplaneViewModel, AddAirplaneCommand>()
				.IgnoreAllPropertiesWithAnInaccessibleSetter()
				.ConstructUsing(c => new AddAirplaneCommand(c.Code, c.Model, c.NumberOfPassengers));

			CreateMap<AirplaneViewModel, UpdateAirplaneCommand>()
				.IgnoreAllPropertiesWithAnInaccessibleSetter()
				.ConstructUsing(c => new UpdateAirplaneCommand(c.Id, c.Code, c.Model, c.NumberOfPassengers));
		}
	}
}

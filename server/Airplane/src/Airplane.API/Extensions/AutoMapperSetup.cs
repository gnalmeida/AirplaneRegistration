using System;
using Airplane.Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Airplane.API.Extensions
{
	public static class AutoMapperSetup
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper();

			AutoMapperConfig.RegisterMappings();
		}
	}
}

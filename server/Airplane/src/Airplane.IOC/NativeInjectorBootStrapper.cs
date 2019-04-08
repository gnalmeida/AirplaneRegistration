using Microsoft.Extensions.DependencyInjection;
using Airplane.Application.Interfaces;
using Airplane.Application.Services;
using Airplane.Domain.Handlers;
using Airplane.Domain.Commands;
using Airplane.Domain.Core.Interfaces.Handlers;
using Airplane.Data.UoW;
using Airplane.Domain.Interfaces.Repository;
using Airplane.Data.Repository;
using Airplane.Data.Context;
using Airplane.Domain.Core.Notifications;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Bus;

namespace Airplane.IOC
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{			
			services.AddScoped<IAirplaneAppService, AirplaneAppService>();

			services.AddScoped<IHandler<AddAirplaneCommand>, AirplaneCommandHandler>();
			services.AddScoped<IHandler<UpdateAirplaneCommand>, AirplaneCommandHandler>();
			services.AddScoped<IHandler<RemoveAirplaneCommand>, AirplaneCommandHandler>();
			services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

			services.AddScoped<IAirplaneRepository, AirplaneRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<AirplaneContext>();

			services.AddScoped<IBus, InMemoryBus>();
		}
	}
}

using Airplane.Domain.Commands;
using Airplane.Domain.Core.Interfaces.Handlers;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Domain.Interfaces.Repository;
using Airplane.Domain.Core.Notifications;
using System.Linq;

namespace Airplane.Domain.Handlers
{
	public class AirplaneCommandHandler : CommandHandler,
		IHandler<AddAirplaneCommand>,
		IHandler<UpdateAirplaneCommand>,
		IHandler<RemoveAirplaneCommand>
	{
		private readonly IAirplaneRepository _airplaneRepository;

		public AirplaneCommandHandler(IAirplaneRepository airplaneRepository, IUnitOfWork uow, IBus bus, Core.Interfaces.Handlers.IDomainNotificationHandler<DomainNotification> notifications)
			:base(uow, bus, notifications)
		{
			_airplaneRepository = airplaneRepository;
		}

		public void Handle(AddAirplaneCommand message)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var airplane = new Entities.Airplane(message.Code, message.Model, message.NumberOfPassengers);

			if (_airplaneRepository.Find(a => a.Code == message.Code).Any())
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, "Código já cadastrado"));
				return;
			}

			_airplaneRepository.Add(airplane);

			Commit();
		}

		public void Handle(UpdateAirplaneCommand message)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var airplane = _airplaneRepository.Get(message.Id);

			if(airplane == null)
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, "Aeronave não encontrada"));
				return;
			}

			if(_airplaneRepository.Find(a => a.Code == message.Code && a.Id != message.Id).Any())
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, "Código já cadastrado"));
				return;
			}
				
			airplane.SetCode(message.Code);
			airplane.SetModel(message.Model);
			airplane.SetNumberOfPassengers(message.NumberOfPassengers);

			_airplaneRepository.Update(airplane);

			Commit();
		}

		public void Handle(RemoveAirplaneCommand message)
		{
			var airplane = _airplaneRepository.Get(message.Id);

			if (airplane == null)
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, "Aeronave não encontrada"));
				return;
			}

			_airplaneRepository.Remove(airplane.Id);

			Commit();
		}

	}
}

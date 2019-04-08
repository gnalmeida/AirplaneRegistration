using Airplane.Domain.Core.Commands;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Domain.Core.Interfaces.Handlers;
using Airplane.Domain.Core.Notifications;
using Airplane.Domain.Interfaces.Repository;
using FluentValidation.Results;

namespace Airplane.Domain.Handlers
{
	public class CommandHandler
	{
		private readonly IUnitOfWork _uow;
		protected readonly IBus _bus;
		private readonly DomainNotificationHandler _notifications;

		public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
		{
			_uow = uow;
			_notifications = (DomainNotificationHandler)notifications;
			_bus = bus;
		}

		protected void NotifyValidationErrors(Command message)
		{
			foreach (var error in message.ValidationResult.Errors)
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
			}
		}

		protected void NotificarValidacoesErro(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				_bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
			}
		}

		protected bool Commit()
		{
			if (_notifications.HasNotifications()) return false;
			var commandResponse = _uow.Commit();
			if (commandResponse.Success) return true;

			_bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
			return false;
		}
	}

}

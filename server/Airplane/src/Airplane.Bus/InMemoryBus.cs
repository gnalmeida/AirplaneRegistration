using Airplane.Domain.Core.Events;
using System;


namespace Airplane.Bus
{
	public sealed class InMemoryBus : Domain.Core.Interfaces.Bus.IBus
	{
		public static Func<IServiceProvider> ContainerAccessor { get; set; }
		private static IServiceProvider Container => ContainerAccessor();

		public void RaiseEvent<T>(T theEvent) where T : Event
		{
			Publish(theEvent);
		}

		public void SendCommand<T>(T theCommand) where T : Domain.Core.Commands.Command
		{
			Publish(theCommand);
		}

		private static void Publish<T>(T message) where T : Domain.Core.Events.Message
		{
			if (Container == null) return;

			var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
				? typeof(Domain.Core.Interfaces.Handlers.IDomainNotificationHandler<T>)
				: typeof(Domain.Core.Interfaces.Handlers.IHandler<T>));

			((Domain.Core.Interfaces.Handlers.IHandler<T>)obj).Handle(message);
		}
	}
}

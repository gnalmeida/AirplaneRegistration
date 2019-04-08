using Airplane.Domain.Core.Events;
using System.Collections.Generic;

namespace Airplane.Domain.Core.Interfaces.Handlers
{
	public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
	{
		bool HasNotifications();
		List<T> GetNotifications();
	}
}

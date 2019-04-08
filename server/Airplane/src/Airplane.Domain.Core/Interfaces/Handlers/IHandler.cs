using Airplane.Domain.Core.Events;

namespace Airplane.Domain.Core.Interfaces.Handlers
{
	public interface IHandler<in T> where T : Message
	{
		void Handle(T message);
	}
}

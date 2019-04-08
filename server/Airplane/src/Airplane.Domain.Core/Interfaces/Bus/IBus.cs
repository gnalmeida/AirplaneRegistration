using Airplane.Domain.Core.Commands;
using Airplane.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Core.Interfaces.Bus
{
	public interface IBus
	{
		void RaiseEvent<T>(T theEvent) where T : Event;
		
		void SendCommand<T>(T theCommand) where T : Command;
	}
}

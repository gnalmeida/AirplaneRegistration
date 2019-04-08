using Airplane.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Commands
{
	public class RemoveAirplaneCommand : Command
	{
		public RemoveAirplaneCommand(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; protected set; }

		public override bool IsValid()
		{
			throw new NotImplementedException();
		}
	}
}

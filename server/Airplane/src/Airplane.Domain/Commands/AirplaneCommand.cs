using Airplane.Domain.Core.Commands;
using System;

namespace Airplane.Domain.Commands
{
	public class AirplaneCommand : Command
	{
		public Guid Id { get; protected set; }
		public string Code { get; protected set; }
		public string Model { get; protected set; }
		public int NumberOfPassengers { get; protected set; }

		public override bool IsValid()
		{
			return ValidationResult.IsValid;
		}
	}
}

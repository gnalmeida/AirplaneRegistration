using Airplane.Domain.Core.Commands;
using Airplane.Domain.Validation;
using System;

namespace Airplane.Domain.Commands
{
	public class UpdateAirplaneCommand : AirplaneCommand
	{
		public UpdateAirplaneCommand(Guid id, string code, string model, int numberOfPassengers)
		{
			Id = id;
			Code = code;
			Model = model;
			NumberOfPassengers = numberOfPassengers;
		}

		public override bool IsValid()
		{
			ValidationResult = new UpdateAirplaneCommandValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

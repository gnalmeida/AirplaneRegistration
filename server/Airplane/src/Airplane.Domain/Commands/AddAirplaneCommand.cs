using Airplane.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Commands
{
	public class AddAirplaneCommand : AirplaneCommand
	{
		public AddAirplaneCommand(string code, string model, int numberOfPassengers)
		{
			Code = code;
			Model = model;
			NumberOfPassengers = numberOfPassengers;
		}

		public override bool IsValid()
		{
			ValidationResult = new AddAirplaneCommandValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

using Airplane.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Validation
{
	public class AddAirplaneCommandValidation : AirplaneValidation<AddAirplaneCommand>
	{
		public AddAirplaneCommandValidation()
		{
			this.ValidateCode();
			this.ValidateModel();
			this.ValidateNumberOfPassenger();
		}
	}
}

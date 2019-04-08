using Airplane.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Validation
{
	public class UpdateAirplaneCommandValidation : AirplaneValidation<UpdateAirplaneCommand>
	{
		public UpdateAirplaneCommandValidation()
		{
			this.ValidateCode();
			this.ValidateModel();
			this.ValidateNumberOfPassenger();
		}
	}
}

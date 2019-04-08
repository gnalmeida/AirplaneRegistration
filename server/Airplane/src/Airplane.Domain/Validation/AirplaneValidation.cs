using Airplane.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Domain.Validation
{
	public class AirplaneValidation<T> : AbstractValidator<T> where T : AirplaneCommand
	{
		protected void ValidateCode()
		{
			RuleFor(c => c.Code)
				.NotEmpty().WithMessage("Code é obrigatório")
				.Length(2, 20).WithMessage("Model deve ter no máximo 20 caracteres");
		}

		protected void ValidateModel()
		{
			RuleFor(c => c.Model)
				.NotEmpty().WithMessage("Model é obrigatório")
				.Length(2, 30).WithMessage("Model deve ter no máximo 30 caracteres");
		}

		protected void ValidateNumberOfPassenger()
		{
			RuleFor(c => c.NumberOfPassengers)
				.GreaterThan(4).WithMessage("Deve ter no mínimo 5 passageiros");
		}
	}
}

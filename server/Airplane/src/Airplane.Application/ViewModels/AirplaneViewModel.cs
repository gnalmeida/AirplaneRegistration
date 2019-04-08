using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airplane.Application.ViewModels
{
	public class AirplaneViewModel
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Code é obrigatório")]
		[MaxLength(20, ErrorMessage = "O tamanho máximo do Nome é {1}")]
		public string Code { get; set; }

		[Required(ErrorMessage = "Model é obrigatório")]
		[MaxLength(30, ErrorMessage = "O tamanho máximo do Nome é {1}")]
		public string Model { get; set; }

		public int NumberOfPassengers { get; set; }

		public DateTime? Created { get; set; }
	}
}

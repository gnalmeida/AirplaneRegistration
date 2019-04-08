using Airplane.Domain.Core.Models;
using System;

namespace Airplane.Domain.Entities
{
	public class Airplane : Entity<Airplane>
	{
		public Airplane(string code, string model, int numberOfPassengers)
		{
			Id = Guid.NewGuid();
			Code = code;
			Model = model;
			NumberOfPassengers = numberOfPassengers;
		}

		public string Code { get; private set; }
		public string Model { get; private set; }
		public int NumberOfPassengers { get; private set; }

		public void SetCode(string code)
		{
			this.Code = code;
		}

		public void SetModel(string model)
		{
			this.Model = model;
		}

		public void SetNumberOfPassengers(int numberOfPassengers)
		{
			this.NumberOfPassengers = numberOfPassengers;
		}
	}
}

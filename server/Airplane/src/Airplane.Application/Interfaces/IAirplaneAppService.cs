using Airplane.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Application.Interfaces
{
	public interface IAirplaneAppService
	{
		IEnumerable<AirplaneViewModel> GetAll();
		AirplaneViewModel Get(Guid id);
		void Add(AirplaneViewModel airplaneViewModel);
		void Update(AirplaneViewModel airplaneViewModel);
		void Remove(Guid id);
	}
}

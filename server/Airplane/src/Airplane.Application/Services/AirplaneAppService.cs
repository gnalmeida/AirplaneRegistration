using Airplane.Application.Interfaces;
using Airplane.Application.ViewModels;
using Airplane.Domain.Commands;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Domain.Interfaces.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Application.Services
{
	public class AirplaneAppService : IAirplaneAppService
	{
		private readonly IBus _bus;
		private readonly IMapper _mapper;
		private readonly IAirplaneRepository _airplaneRepository;

		public AirplaneAppService(IBus bus, IMapper mapper, IAirplaneRepository airplaneRepository)
		{
			_bus = bus;
			_mapper = mapper;
			_airplaneRepository = airplaneRepository;
		}

		public IEnumerable<AirplaneViewModel> GetAll()
		{
			return _mapper.Map<IEnumerable<AirplaneViewModel>>(_airplaneRepository.GetAll());
		}
		
		public AirplaneViewModel Get(Guid id)
		{
			return _mapper.Map<AirplaneViewModel>(_airplaneRepository.Get(id));
		}
		
		public void Add(AirplaneViewModel airplaneViewModel)
		{
			var command = _mapper.Map<AddAirplaneCommand>(airplaneViewModel);
			_bus.SendCommand(command);
		}
		
		public void Update(AirplaneViewModel airplaneViewModel)
		{
			var command = _mapper.Map<UpdateAirplaneCommand>(airplaneViewModel);
			_bus.SendCommand(command);
		}

		public void Remove(Guid id)
		{
			_bus.SendCommand(new RemoveAirplaneCommand(id));
		}
	}
}

using System;
using System.Collections.Generic;
using Airplane.Application.Interfaces;
using Airplane.Application.ViewModels;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Domain.Core.Interfaces.Handlers;
using Airplane.Domain.Core.Notifications;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Airplane.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[EnableCors("MyPolicy")]
	public class AirplaneController : BaseController
    {
		private readonly IAirplaneAppService _airplaneAppService;

		public AirplaneController(IAirplaneAppService airplaneAppService, 
			IDomainNotificationHandler<DomainNotification> notifications,
			IBus bus)
			:base(notifications, bus)
		{
			_airplaneAppService = airplaneAppService;
		}

		[HttpGet]
		public IEnumerable<AirplaneViewModel> Get()
		{
			return _airplaneAppService.GetAll();
		}

		[HttpGet("{id}")]
		public AirplaneViewModel Get(Guid id)
		{
			return _airplaneAppService.Get(id);
		}

		[HttpPost]
		public IActionResult Post([FromBody] AirplaneViewModel airplaneViewModel)
		{
			if (!ModelState.IsValid)
			{
				NotificarErroModelInvalida();
				return Response();
			}

			_airplaneAppService.Add(airplaneViewModel);

			return Response(airplaneViewModel);
		}

		[HttpPut]
		public IActionResult Put([FromBody] AirplaneViewModel airplaneViewModel)
		{
			if (!ModelState.IsValid)
			{
				NotificarErroModelInvalida();
				return Response();
			}

			_airplaneAppService.Update(airplaneViewModel);

			return Response(airplaneViewModel);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			_airplaneAppService.Remove(id);

			return Response();
		}
	}
}
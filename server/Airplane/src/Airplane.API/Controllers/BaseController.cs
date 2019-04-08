﻿using System.Linq;
using Airplane.Domain.Core.Interfaces.Bus;
using Airplane.Domain.Core.Interfaces.Handlers;
using Airplane.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Airplane.API.Controllers
{
	public class BaseController : Controller
    {
		private readonly IDomainNotificationHandler<DomainNotification> _notifications;
		private readonly IBus _bus;

		protected BaseController(IDomainNotificationHandler<DomainNotification> notifications, IBus bus)
		{
			_notifications = notifications;
			_bus = bus;
		}

		protected new IActionResult Response(object result = null)
		{
			if (OperacaoValida())
			{
				return Ok(new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new
			{
				success = false,
				errors = _notifications.GetNotifications().Select(n => n.Value)
			});
		}

		protected bool OperacaoValida()
		{
			return (!_notifications.HasNotifications());
		}

		protected void NotificarErroModelInvalida()
		{
			var erros = ModelState.Values.SelectMany(v => v.Errors);
			foreach (var erro in erros)
			{
				var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
				NotificarErro(string.Empty, erroMsg);
			}
		}

		protected void NotificarErro(string codigo, string mensagem)
		{
			_bus.RaiseEvent(new DomainNotification(codigo, mensagem));
		}
	}
}
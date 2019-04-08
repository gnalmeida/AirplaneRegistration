using Airplane.Domain.Core.Commands;
using System;

namespace Airplane.Domain.Interfaces.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResponse Commit();
	}
}

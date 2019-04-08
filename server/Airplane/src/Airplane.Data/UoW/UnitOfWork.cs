using Airplane.Data.Context;
using Airplane.Domain.Core.Commands;
using Airplane.Domain.Interfaces.Repository;

namespace Airplane.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AirplaneContext _context;

		public UnitOfWork(AirplaneContext context)
		{
			_context = context;
		}

		public CommandResponse Commit()
		{
			var rowsAffected = _context.SaveChanges();
			return new CommandResponse(rowsAffected > 0);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}

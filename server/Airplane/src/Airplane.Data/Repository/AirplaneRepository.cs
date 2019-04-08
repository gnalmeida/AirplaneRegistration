using Airplane.Domain.Entities;

namespace Airplane.Data.Repository
{
	public class AirplaneRepository : Repository<Airplane.Domain.Entities.Airplane>, Domain.Interfaces.Repository.IAirplaneRepository
	{
		public AirplaneRepository(Context.AirplaneContext context) : base(context)
		{

		}
	}
}

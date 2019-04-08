using Airplane.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane.Data.Mappings
{
	public class AirplaneMap : EntityTypeConfiguration<Domain.Entities.Airplane>
	{
		public override void Map(EntityTypeBuilder<Domain.Entities.Airplane> builder)
		{
			// Primary Key
			builder.HasKey(t => t.Id);

			// Properties
			builder.Property(t => t.Code).IsRequired().HasMaxLength(20);

			builder.Property(t => t.Model).IsRequired().HasMaxLength(30);

			builder.Property(t => t.NumberOfPassengers).IsRequired();
		}
	}
}

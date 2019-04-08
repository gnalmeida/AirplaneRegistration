using Airplane.Domain.Core.Events;
using System;
using FluentValidation.Results;

namespace Airplane.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
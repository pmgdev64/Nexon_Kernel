using System;
using Cosmos.System;

namespace NexonKernel.Command {
    public abstract class BaseCommand : ICommand {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract void Execute(string[] args);
    }
}
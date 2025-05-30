using System;
using Cosmos.System;

namespace NexonKernel.Command {
    public interface ICommand {
        public Action<List<string>, Dictionary<string, string>> Execute { get; set; }
        string Name { get; }
        string Description { get; }
        void Execute(string[] args);
    }
}
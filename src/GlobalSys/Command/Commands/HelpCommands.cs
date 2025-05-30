using System;
using Cosmos.System;
using NexonKernel.Command;

namespace NexonKernel.Command {
    public class HelpCommand : BaseCommand {
        private List<ICommand> _commands;

        public HelpCommand(List<ICommand> commands) {
            _commands = commands;
        }

        public override string Name = "Help";
        public override string Description = "Displays available commands";

        public override void Execute(string[] args) {
            Console.WriteLine("Nexon Kernel Commands Helper");
            Console.WriteLine("This is a list of Available Commands In Nexon Kernel:")
            foreach (var command in _commands) {
                Console.WriteLine($"- {command.Name}: {command.Description}");
            }
            Console.WriteLine("For More Information, Visit https://kawaiiproject.neocities.org/Contents/nexon_kernel.");
        }
    }
}

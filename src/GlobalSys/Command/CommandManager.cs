using System;
using Cosmos.System;

namespace NexonKernel.Command {
    public class CommandManager {
        private List<ICommand> _commands = new List<ICommand>();

        public CommandManager() {
            // Add commands here
            _commands.Add(new GetCpuInfoCommand());
            _commands.Add(new HelpCommand(_commands));
        }

        public void ExecuteCommand(string input) {
            var parts = input.Split(' ');
            var cmdName = parts[0].ToLower();
            var args = parts.Length > 1 ? parts[1..] : new string[0];

            var cmd = _commands.Find(c => c.Name == cmdName);
            if (cmd != null) {
                cmd.Execute(args);
            } 
            else {
                Console.WriteLine($"Command '{cmdName}' Is not found in the command list or program not available. make sure you command or program are added, and try again.");
            }
        }
    }
}

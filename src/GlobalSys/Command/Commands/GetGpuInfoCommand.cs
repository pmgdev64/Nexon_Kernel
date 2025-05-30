using System;
using Cosmos.System;
using NexonKernel.Command;

namespace NexonKernel.Command {
    public class GetCpuInfoCommand : BaseCommand {
        public override string Name = "Getcpuinfo";
        public override string Description = "Shows CPU Information";

        public override void Execute(string[] args) {
            Console.WriteLine($"Vendor: {Cosmos.Core.CPU.GetCPUVendorName()}");
            Console.WriteLine($"Brand: {Cosmos.Core.CPU.GetCPUBrandString()}");
            Console.WriteLine($"Speed: {Cosmos.Core.CPU.GetCPUCycleSpeed()} MHz");
        }
    }
}
using System.Runtime.InteropServices;

namespace NexonKernel.Misc
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct CPUID
    {
        public uint EAX;
        public uint EBX;
        public uint ECX;
        public uint EDX;
    }
}
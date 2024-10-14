using System.Diagnostics;

namespace Crony
{
    public static class PerformanceMonitor
    {
        public static float GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            return cpuCounter.NextValue();
        }

        public static float GetMemoryUsage()
        {
            var memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            return memCounter.NextValue();
        }

        public static float GetDiskUsage()
        {
            var diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            return diskCounter.NextValue();
        }
    }
}
using System.Diagnostics;

namespace Crony.SystemMonitoring
{
    class SystemMonitoring
    {
        public static (float Cpu, float Ram, float Gpu) GetStatus()
        {
            float cpuUsage = GetCpuUsage();
            float ramUsage = GetRamUsage();
            float gpuUsage = GetGpuUsage();
            return (cpuUsage, ramUsage, gpuUsage);
        }

        private static float GetCpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            return cpuCounter.NextValue();
        }

        private static float GetRamUsage()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return ramCounter.NextValue();
        }

        private static float GetGpuUsage()
        {
            return 0; // Заглушка
        }
    }
}

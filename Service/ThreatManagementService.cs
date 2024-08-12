
using IronDome.Data;
using IronDome.Dto;

namespace IronDome.Service
{
    public class ThreatManagementService(ApplicationDbContext context) : IThreatManagementService
    {
        public async Task Launch(CancellationToken token, int seconds, ThreatManagement threat)
        {
            int counter = seconds;
            using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));
            while (await timer.WaitForNextTickAsync(token) && counter > 0)
            {
                Console.WriteLine($"Launching {threat.ThreatSource}: {threat.ThreatType} {counter--}");
            }

            threat.IsActive = false;
        }
    }
}

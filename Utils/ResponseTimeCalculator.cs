using IronDome.Models;

namespace IronDome.Utils
{
    public static class ResponseTimeCalculator
    {
        public static double CalculateResponseTime(ThreatModel threat) => 
            ((int)threat.ThreatType / (int)threat.ThreatSource) * 60;

    }
}

using System;
using System.Collections.Generic;

namespace WaterJugAPI.Infrastructure
{
    public interface IWaterJugService
    {
        List<string> MinSteps(int bucketX, int bucketY, int mazureBuckets);
    }
}

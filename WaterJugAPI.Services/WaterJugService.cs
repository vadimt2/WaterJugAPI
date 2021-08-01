using System;
using System.Collections.Generic;
using System.Linq;
using WaterJugAPI.Infrastructure;

namespace WaterJugAPI.Services
{
    public class WaterJugService : IWaterJugService
    {
        private List<string> Pour(int bucketX, int bucketY, int mazureBuckets)
        {
            List<string> steps = new List<string>();

            var fromBucketX = bucketX;
            int to = 0;

            int step = 1;
            steps.Add("Fill bucket x");

            while (fromBucketX != mazureBuckets && to != mazureBuckets)
            {
                int minPouredAmount = Math.Min(fromBucketX, bucketY - to);

                to += minPouredAmount;
                fromBucketX -= minPouredAmount;

                steps.Add("Transfer bucket x to bucket y");
                step++;

                if (fromBucketX == mazureBuckets || to == mazureBuckets)
                    break;

                if (fromBucketX == 0)
                {
                    steps.Add("Fill bucket x");
                    fromBucketX = bucketX;
                    step++;
                }

                if (to == bucketY)
                {
                    steps.Add("Fill bucket y");
                    to = 0;
                    step++;
                }
            }

            string lastStep = steps.Last();
            if (string.IsNullOrEmpty(lastStep))
            {

                lastStep += " Solved";
                steps[steps.Count - 1] = lastStep;
            }

            return steps;
        }

        private int GreatestCommonDivisor(int bucketX, int bucketY)
        {
            if (bucketY == 0)
                return bucketX;

            return GreatestCommonDivisor(bucketY, bucketX % bucketY);
        }

        public List<string> MinSteps(int bucketX, int bucketY, int mazureBuckets)
        {
            List<string> steps = new List<string> {"No Solution"};

            if (bucketX > bucketY)
            {
                int temp = bucketX;
                bucketX = bucketY;
                bucketY = temp;
            }

            if (mazureBuckets > bucketY)
                return steps;

            if (mazureBuckets % GreatestCommonDivisor(bucketY, bucketX) != 0)
                return steps;

            return Pour(bucketX, bucketY, mazureBuckets);
        }
    }
}

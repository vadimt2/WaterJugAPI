using System;
using System.ComponentModel.DataAnnotations;

namespace WaterJugAPI.Core.Entities
{
    public class WaterJug
    {
        [Required]
        public int BucketX { get; set; }
        [Required]
        public int BucketY { get; set; }
        [Required]
        public int MazureBuckets { get; set; }

    }
}

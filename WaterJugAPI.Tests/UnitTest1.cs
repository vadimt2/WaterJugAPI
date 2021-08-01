using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WaterJugAPI.Controllers;
using WaterJugAPI.Core.Entities;
using WaterJugAPI.Infrastructure;
using Xunit;

namespace WaterJugAPI.Tests
{
    public class UnitTest1
    {
        private readonly IServiceProvider _services =
            Program.CreateHostBuilder(new string[] { }).Build().Services;

        [Fact]
        public void Post_Water_Jug_Expected_Result()
        {
            // Arrange
            int count = 4;

            // Act
            var myService = _services.GetRequiredService<IWaterJugService>();
            var controller = new WaterJugController(myService);
            var waterJuug = new WaterJug() { BucketX = 2, BucketY = 10, MazureBuckets = 4};
            var actionResult = controller.Post(waterJuug);
            var result = actionResult as OkObjectResult;
            var waterJugsStepsResult = result.Value as IEnumerable<string>;

            // Assert
            Assert.Equal(count, waterJugsStepsResult.Count());
        }

        [Fact]
        public void Post_Water_Jug_Returns_Error_400()
        {
            // Act
            var myService = _services.GetRequiredService<IWaterJugService>();
            var controller = new WaterJugController(myService);
            var waterJuug = new WaterJug() { BucketX = 0, BucketY = 0, MazureBuckets = 0 };
            var actionResult = controller.Post(waterJuug);
            var result = actionResult;
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_Water_Jug_Expected_Result_No_Sulotion()
        {
            // Arrange
            int count = 1;

            // Act
            var myService = _services.GetRequiredService<IWaterJugService>();
            var controller = new WaterJugController(myService);
            var waterJuug = new WaterJug() { BucketX = 1, BucketY = 1, MazureBuckets = 1 };
            var actionResult = controller.Post(waterJuug);
            var result = actionResult as OkObjectResult;
            var waterJugsStepsResult = result.Value as IEnumerable<string>;

            // Assert
            Assert.Equal(count, waterJugsStepsResult.Count());
        }
    }
}

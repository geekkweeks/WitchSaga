using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WitchSaga.Application.Dto;
using WitchSaga.Application.Services;

namespace WitchSaga.Application.Tests
{
    [TestClass]
    public class WitchTest
    {
        [TestMethod]
        public void TestExpected()
        {
            var services = new ServiceCollection()
                .AddLogging(config => config.AddConsole())
                .BuildServiceProvider();
            using var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var svc = new KillService(loggerFactory.CreateLogger<KillService>());

            var requests = new List<PersonDto>
            {
                new PersonDto
                {
                    Name = "Person 1",
                    AgeOfDeath = 10,
                    YearOfDeath = 12
                },
                new PersonDto
                {
                    Name = "Person 2",
                    AgeOfDeath = 13,
                    YearOfDeath = 17
                }
            };

            var actualResult = svc.GetPeopleKilledInfo(requests);
            Assert.AreEqual(200, (int)actualResult.ResponseCode);

        }

        [TestMethod]
        public void TestUnExpected()
        {
            var services = new ServiceCollection()
               .AddLogging(config => config.AddConsole())
               .BuildServiceProvider();
            using var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var svc = new KillService(loggerFactory.CreateLogger<KillService>());

            var requests = new List<PersonDto>
            {
                new PersonDto
                {
                    Name = "Person 1",
                    AgeOfDeath = 12,
                    YearOfDeath = 11
                },
                new PersonDto
                {
                    Name = "Person 2",
                    AgeOfDeath = 13,
                    YearOfDeath = 17
                }
            };

            var actualResult = svc.GetPeopleKilledInfo(requests);
            Assert.AreEqual(-1, actualResult.AverageKilled);

        }


    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchSaga.Application.KilledServices
{
    public class KillService : IKillService
    {
        private readonly ILogger<KillService> _log;
        private readonly IConfiguration _config;

        public KillService(ILogger<KillService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            for (int i = 0; i < int.Parse(_config.GetSection("LoopTimes").Value); i++)
            {
                _log.LogInformation("Run number { runNumber }", i);
            }
        }
    }
}

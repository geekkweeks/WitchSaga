using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchSaga.Application.Dto;
using WitchSaga.Common.Helpers;

namespace WitchSaga.Application.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ILogger<PeopleService> _log;

        public PeopleService(ILogger<PeopleService> log)
        {
            _log = log;
        }

        public PersonDto GetPersonDetail(PersonDto model)
        {
            model.YearBorn = CommonHelper.GetSubtraction(model.AgeOfDeath, model.YearOfDeath);
            _log.LogInformation($"Person {model.Name} born on {model.YearBorn}");
            return model;
        }
    }
}

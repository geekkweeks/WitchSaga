using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchSaga.Application.Dto;
using WitchSaga.Common.Helpers;
using WitchSaga.Common.Models;

namespace WitchSaga.Application.Services
{
    public class KillService : IKillService
    {
        private readonly ILogger<KillService> _log;

        public KillService(ILogger<KillService> log)
        {
            _log = log;
        }

        
        public SummaryKilledDto GetPeopleKilledInfo(List<PersonDto> persons)
        {
            _log.LogInformation("on GetPeopleKilled running.");

            var model = new SummaryKilledDto
            {
                Persons = persons
            };
            
            foreach (var item in model.Persons.Select((value, i) => new { i, value }))
            {
                item.value.YearBorn = CommonHelper.GetSubtraction(item.value.AgeOfDeath, item.value.YearOfDeath);
                item.value.PeopleKilled = GetPeopleKilled(item.value.YearBorn);
            }

            model.Persons = model.Persons.OrderBy(o => o.YearBorn).ToList();

            for (int i = 0; i < model.Persons.Select(s => s.YearBorn).OrderByDescending(s => s).FirstOrDefault(); i++)
            {
                var data = model.Persons.Where(w => w.YearBorn == i).Any();
                if (!data)
                {
                    //add data
                    persons.Add(new PersonDto
                    {
                        YearBorn = i,
                        PeopleKilled = GetPeopleKilled(i),
                    });
                }
            }

            model.AverageKilled = CommonHelper.GetAverage(persons.Select(s => s.PeopleKilled).ToList());
            model.ResponseCode = 200;
            return model;
        }        

        #region Private Functions
        private int GetPeopleKilled(int year)
        {
            var temp = new List<int>();
            for(int i = 0; i < year; i++)
            {
                if(temp.Count < 2)
                    temp.Add(1);
                else
                {
                    //formula [i-2] + [i-1]
                    var currenTotal = temp[i - 1] + temp[i - 2];
                    temp.Add(currenTotal);
                }                
            }

            if(temp.Any())
                return temp.Sum();

            return 0;        

        }

        //private decimal GetAverageKilled(List<int> persons)
        //{
        //    return CommonHelper.GetAverage(persons);
        //}
        #endregion
    }
}

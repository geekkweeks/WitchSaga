using System.Collections.Generic;
using WitchSaga.Application.Dto;
using WitchSaga.Common.Models;

namespace WitchSaga.Application.Services
{
    public interface IKillService
    {
        SummaryKilledDto GetPeopleKilledInfo(List<PersonDto> persons);
    }
}
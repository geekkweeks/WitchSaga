using System.Collections.Generic;
using WitchSaga.Application.Dto;

namespace WitchSaga.Application.KilledServices
{
    public interface IKillService
    {
        SummaryKilledDto GetPeopleKilledInfo(List<PersonDto> persons);
    }
}
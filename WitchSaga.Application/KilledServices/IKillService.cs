using System.Collections.Generic;
using WitchSaga.Application.Dto;
using WitchSaga.Common.Models;

namespace WitchSaga.Application.KilledServices
{
    public interface IKillService
    {
        DataResponse GetPeopleKilledInfo(List<PersonDto> persons);
    }
}
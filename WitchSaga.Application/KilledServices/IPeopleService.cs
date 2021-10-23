using WitchSaga.Application.Dto;

namespace WitchSaga.Application.KilledServices
{
    public interface IPeopleService
    {
        PersonDto GetPersonDetail(PersonDto model);
    }
}
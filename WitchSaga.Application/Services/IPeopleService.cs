using WitchSaga.Application.Dto;

namespace WitchSaga.Application.Services
{
    public interface IPeopleService
    {
        PersonDto GetPersonDetail(PersonDto model);
    }
}
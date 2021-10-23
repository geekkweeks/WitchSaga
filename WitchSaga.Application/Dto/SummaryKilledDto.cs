using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchSaga.Common.Models;

namespace WitchSaga.Application.Dto
{
    public class SummaryKilledDto : BaseResponseModel
    {
        public decimal AverageKilled { get; set; }
        public List<PersonDto> Persons { get; set; }
    }
}

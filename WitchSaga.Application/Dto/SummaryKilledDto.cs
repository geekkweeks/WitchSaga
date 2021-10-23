using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchSaga.Application.Dto
{
    public class SummaryKilledDto : BaseDto
    {
        public decimal AverageKilled { get; set; }
        public List<PersonDto> Persons { get; set; }
    }
}

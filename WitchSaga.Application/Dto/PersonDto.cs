using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchSaga.Application.Dto
{
    public class PersonDto : BaseDto
    {
        public int YearBorn { get; set; }
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }
        public int PeopleKilled { get; set; }
    }
}

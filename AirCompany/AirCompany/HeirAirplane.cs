using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class HeirAirplane: Airplane
    {
        public HeirAirplane(int passengers, float consuption, int altitudeIncrement):base(passengers, consuption, altitudeIncrement)
        {
        }

        protected override float ForsageStep()
        {
            return 1.5F;
        }
    }
}

using System;

namespace AirCompany
{
    class Airplane
    {
        public int Passengers { get; private set; }
        
        private string _autopilotOn;
        public string AutoPilotOn 
        { 
            get
            {
                return _autopilotOn;
            }
            set
            {
                if(value=="Off" || value=="On")
                {
                    _autopilotOn=value;
                }
                else
                {
                    Console.WriteLine("Uncorrect value!");
                }
            }
        }

        private string _forsageOn;
        public string ForsageOn 
        { 
            get
            {
                return _forsageOn;
            }
            set
            {
                if (value == "Off" || value == "On")
                {
                    _forsageOn = value;
                }
                else
                {
                    Console.WriteLine("Uncorrect value!");
                }
            }
        }

        /// <summary>
        /// Fuel consuption. kg/km
        /// </summary>
        public float Consuption { get; private set; }

        public int Altitude { get; private set; }


        public static decimal TicketPrice { get; set; }
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }

        private int _altitudeIncrement;

       
        public Airplane(int passengers, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = "Off";
            ForsageOn = "Off";
            MaxAltitudeAuto = 10000;
            MinAltitudeAuto = 2000;
            Passengers = passengers;
            Consuption = consuption;
            _altitudeIncrement = altitudeIncrement;
        }

        public int Climb(int increment)
        {
            if (AutoPilotOn == "Off")
            {
                return Altitude += increment;
            }
            else if (Altitude + increment < MaxAltitudeAuto)
            {
                return Altitude += increment;
            }
            else
            {
                return Altitude = MaxAltitudeAuto;
            }
        }

        public int Down(int increment)
        {
            if (AutoPilotOn=="On")
            {
                if (Altitude - increment > MinAltitudeAuto)
                {
                    return Altitude -= increment;
                }
                if (Altitude < MinAltitudeAuto) return Altitude;
                return Altitude = MinAltitudeAuto;
            }

            if (Altitude - increment < 0) return Altitude = 0;
            return Altitude -= increment;
        }

        protected virtual float ForsageStep()
        {
            return 2.0F;
        }

        public int SetAltitude(int targetAltitude)
        {
            int tmp=0;
            float forsage_step = 1;
            if(ForsageOn == "On")
            {
                forsage_step = ForsageStep();
            }
            if (AutoPilotOn == "Off")
            {
                if(targetAltitude>0)
                {
                    tmp = targetAltitude;
                }
            }
            else if(AutoPilotOn=="On")
            {
                if(Altitude < targetAltitude)
                {
                    if (targetAltitude > MaxAltitudeAuto)
                    {
                        tmp = MaxAltitudeAuto;
                    }
                    else
                    {
                        tmp = targetAltitude;
                    }
                }
                else if (Altitude > targetAltitude)
                {
                    if (targetAltitude < MinAltitudeAuto)
                    {
                        tmp = MinAltitudeAuto;
                    }
                    else
                    {
                        tmp = targetAltitude;
                    }
                }
            }
            if (Altitude < targetAltitude)
            {
                while (Altitude < tmp)
                {
                    System.Threading.Thread.Sleep(1000);
                    if ((tmp - Altitude)<(_altitudeIncrement* forsage_step))
                    {
                        Climb(tmp - Altitude);
                    }
                    else
                    {
                        Climb((int)(_altitudeIncrement * forsage_step));
                    }
                    Console.WriteLine("Altitude {0} km",Altitude);
                }
                return Altitude;
            }
            else if (Altitude > targetAltitude)
            {
                while (Altitude > tmp && Altitude > 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if ((Altitude-tmp) < _altitudeIncrement)
                    {
                        Down(Altitude - tmp);
                    }
                    else
                    {
                        Down(_altitudeIncrement);
                    }
                    Console.WriteLine("Altitude {0} km", Altitude);
                }
                return Altitude;
            }
            else
            {
                return 0;
            }
        }
        public void Show()
        {
            Console.WriteLine("Current altitude is {0};\nAutopilot {1};\nMode \"Forsage\" {2}.\n",Altitude, AutoPilotOn,ForsageOn);
        }
    }
}



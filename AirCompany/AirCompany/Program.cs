/*Работа с классом Airplane. 
Необходимо сделать:
- добавить статический конструктор. Устанавливать значения по умолчанию для свойств MinAltitudeAuto и MaxAltitudeAuto
- Реализовать метод SetAltitude. Он должен выводить самолет на заданную высоту. Текущая высота должна быть доступна в свойстве Altitude. 
Необходимо учесть ограничения, связанные с автопилотом - если он включен, высота не должна быть выше/ниже заданных пределов
- Реализовать свойство Forsage - при включенном форсаже инкремент подъема удваивается. Динамика снижения не меняется.
- Реализовать интерактивную работу с пользователем через командную строку: циклически запрашивать у пользователя желаемую высоту
- Пользователь из командной строки должен иметь возможность включать/выключать автопилот и форсаж.
- Разместить проект на собственном на GitHub и загрузить в logbook ссылку на репозиторий


Диалог с пользователем должен выглядеть примерно так:

> A=11000                                                                    - пользователь ввел желаемую высоту
> Высота = 11000                                                             - ответ приложения
> A=7000                                                                     - пользователь ввел желаемую высоту
> Высота = 7000                                                              - ответ приложения
> Auto = 1                                                                   - пользователь активировал автопилот
> Автопилот активирован                                                      - ответ приложения
> A=11000                                                                    - пользователь ввел желаемую высоту
> Невозможно занять высоту 11000 в режиме автопилота. Текущая высота = 10000
> F=1                                                                        - пользователь активировал форсаж
... и т.д.*/

using System;

namespace AirCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice=0;
            int value = 0;
            HeirAirplane airplane = new HeirAirplane(140, 2.26F, 1000);
            do
            {
                Console.Clear();
                airplane.Show();
                Console.WriteLine("1. Take off;");
                Console.WriteLine("2. Change the altitude;");
                Console.WriteLine("3. Change mode \"Autopilot\";");
                Console.WriteLine("4. Change mode \"Forsage\";");
                Console.WriteLine("5. To land.");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        airplane.SetAltitude(5000);
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter the target height: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        if(airplane.AutoPilotOn=="On" && value > Airplane.MaxAltitudeAuto)
                        {
                            Console.WriteLine("It is imposible to gain altitude {0} in mode \"Autopilot\". \nMaximum altitude is {1}", value, Airplane.MaxAltitudeAuto);
                        }
                        if (airplane.AutoPilotOn == "On" && value < Airplane.MinAltitudeAuto)
                        {
                            Console.WriteLine("It is imposible to gain altitude {0} in mode \"Autopilot\". Minimum altitude is {1}", value, Airplane.MinAltitudeAuto);
                        }
                        airplane.SetAltitude(value);
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("1. Off autopilot;");
                        Console.WriteLine("2. On autopilot;");
                        Console.WriteLine("3. Change a maximum heigh for mode \"utopilot\";");
                        Console.WriteLine("4. Change a minimum heigh for mode \"utopilot\".");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch(choice)
                        {
                            case 1:
                                airplane.AutoPilotOn = "Off";
                                Console.WriteLine("Autopilot is deactivated!");
                                break;
                            case 2:
                                airplane.AutoPilotOn = "On";
                                Console.WriteLine("Autopilot is activated!");
                                break;
                            case 3:
                                Console.Write("Enter the new value a maximum heigh for mode \"utopilot\": ");
                                value = Convert.ToInt32(Console.ReadLine());
                                Airplane.MaxAltitudeAuto = value;
                                break;
                            case 4:
                                Console.Write("Enter the new value a minimum heigh for mode \"utopilot\": ");
                                value = Convert.ToInt32(Console.ReadLine());
                                Airplane.MinAltitudeAuto = value;
                                break;
                        }
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("1. Off mode \"Forsage\";");
                        Console.WriteLine("2. On mode \"Forsage\".");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                airplane.ForsageOn = "Off";
                                Console.WriteLine("Mode \"Forsage\" is deactivated!");
                                break;
                            case 2:
                                airplane.ForsageOn = "On";
                                Console.WriteLine("Mode \"Forsage\" is activated!");
                                break;
                        }
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 5:
                        Console.Clear();
                        airplane.AutoPilotOn = "Off";
                        airplane.SetAltitude(0);
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            } while (choice != 5);
        }
    }
}
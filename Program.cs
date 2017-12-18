using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApplication2
{

    class Program
    {
        static string CheckKey(string chararray)
        {
            if (chararray == String.Empty)
            {
                return "0";
            }
            else
            {

                chararray.ToCharArray();
                string newstring = "";
                foreach (char ch in chararray)
                {
                    if (Char.IsDigit(ch))
                    {
                        newstring = newstring + ch;
                    }
                }
                return newstring;
            }
        }
        static void Main()
        {

            List<Plane> planes = new List<Plane>();
            Console.WriteLine("Колко са самолетите тип Boeing 737 - ");
            int inner_planes_counter = 1, current_fuel_doscope;
            int boeing737s = int.Parse(CheckKey(Console.ReadLine()));
            if (boeing737s == 0)
            { }
            else
            {
                do
                {
                    Console.WriteLine("Въведете колко гориво има в самолета (Min - 100, Max - 1600) :");
                    current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                    if (current_fuel_doscope > 1600 || current_fuel_doscope < 100)
                    {
                        do
                        {
                            Console.WriteLine("Моля уверете се, че сте въвели число между 100 и 1600");
                            current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                        }
                        while (current_fuel_doscope > 1600 || current_fuel_doscope < 100);
                    }

                    planes.Add(new Plane.Boeing737(name: ("Boeing 737-" + inner_planes_counter), weight: 124, consumation: 75, time_landing: 3, capacity: 1600, passangers: 260, current_fuel: current_fuel_doscope));
                    Console.WriteLine("Успешно въведен самолет {0}, с {1} литра гориво", planes.Last().Name, planes.Last().Current_Fuel);
                    inner_planes_counter++;
                    boeing737s--;
                    Thread.Sleep(600);
                } while (boeing737s > 0 && boeing737s != 0);
            }

            Console.WriteLine("Колко са самолетите тип Boeing 747?");
            inner_planes_counter = 1; current_fuel_doscope = 0;
            int boeing747s = int.Parse(CheckKey(Console.ReadLine()));
            if (boeing747s == 0)
            { }
            else
            {
                do
                {
                    Console.WriteLine("Въведете колко гориво има в самолета (Min - 100, Max - 2200) :");
                    current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                    if (current_fuel_doscope > 2200 || current_fuel_doscope < 100)
                    {
                        do
                        {
                            Console.WriteLine("Моля уверете се, че сте въвели число между 100 и 2200");
                            current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                        }
                        while (current_fuel_doscope > 2200 || current_fuel_doscope < 100);
                    }
                    planes.Add(new Plane.Boeing747(name: "Boeing 747-" + inner_planes_counter, weight: 161, consumation: 175, time_landing: 5, capacity: 2200, passangers: 350, current_fuel: current_fuel_doscope));
                    Console.WriteLine("Успешно въведен самолет {0}, с {1} литра гориво", planes.Last().Name, planes.Last().Current_Fuel);
                    inner_planes_counter++;
                    boeing747s--;
                    Thread.Sleep(600);
                } while (boeing747s > 0);
            }

            Console.WriteLine("Колко са самолетите тип CanadairCRJ700 ?");
            int canadairCRJ700s = int.Parse(CheckKey(Console.ReadLine())); inner_planes_counter = 1; current_fuel_doscope = 0;
            if (canadairCRJ700s == 0)
            { }
            else
            {
                do
                {
                    Console.WriteLine("Въведете колко гориво има в самолета (Min - 100, Max - 950) :");
                    current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                    if (current_fuel_doscope > 950 || current_fuel_doscope < 100)
                    {
                        do
                        {
                            Console.WriteLine("Моля уверете се, че сте въвели число между 100 и 950");
                            current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                        }
                        while (current_fuel_doscope > 950 || current_fuel_doscope < 100);
                    }

                    planes.Add(new Plane.CanadairCRJ700(name: "CanadairCRJ700-" + inner_planes_counter, weight: 90, consumation: 55, time_landing: 4, capacity: 950, passangers: 70, current_fuel: current_fuel_doscope));
                    Console.WriteLine(" Успешно въведен самолет {0}, с {1} литра гориво", planes.Last().Name, planes.Last().Current_Fuel);
                    inner_planes_counter++;
                    canadairCRJ700s--;
                    Thread.Sleep(600);
                } while (canadairCRJ700s > 0);
            }

            Console.WriteLine("Колко са самолетите тип Cessna650XL ?");
            int cessna560XLs = int.Parse(CheckKey(Console.ReadLine())); inner_planes_counter = 1; current_fuel_doscope = 0;
            if (cessna560XLs == 0)
            { }
            else
            {
                do
                {
                    Console.WriteLine("Въведете колко гориво има в самолета (Min - 100, Max - 700) :");
                    current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                    if (current_fuel_doscope > 700 || current_fuel_doscope < 100)
                    {
                        do
                        {
                            Console.WriteLine("Моля уверете се, че сте въвели число между 100 и 700");
                            current_fuel_doscope = int.Parse(CheckKey(Console.ReadLine()));
                        }
                        while (current_fuel_doscope > 700 || current_fuel_doscope < 100);
                    }
                    planes.Add(new Plane.Cessna560XL(name: "Cessna560XL-" + inner_planes_counter, weight: 45, consumation: 30, time_landing: 2, capacity: 700, passangers: 8, current_fuel: current_fuel_doscope));
                    Console.WriteLine("Успешно въведен самолет {0}, с {1} литра гориво", planes.Last().Name, planes.Last().Current_Fuel);
                    inner_planes_counter++;
                    cessna560XLs--;
                    Thread.Sleep(600);
                } while (cessna560XLs > 0);
            }
            if (!planes.Any())
            {
                Console.WriteLine("Не са въведени никакви самолети");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            else
            {
                int planescounter = planes.Count, landing_number = 0, planesAll = planes.Count;
                do
                {
                    landing_number++;
                    planes.OrderByDescending(x => x.Current_Fuel);
                    Plane c = planes[0];
                    int time_landing_DOscope = c.Time_landing;
                    Console.WriteLine("\n {0} каца {1}, защото има {2} литра гориво", planes.First().Name, landing_number, planes.First().Current_Fuel);
                    planes.RemoveAt(0);
                    foreach (Plane plane in planes)
                    {
                        plane.Current_Fuel = plane.Current_Fuel - (plane.Consumation * time_landing_DOscope / 60);
                        Thread.Sleep(600);
                    }
                    planescounter--;
                } while (planescounter > 0);
                Console.WriteLine("Всички {0} самолета са приземени. Добра работа!", planesAll);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }


        class Plane
        {
            public string Name { get; protected set; }
            public int Weight { get; protected set; }
            public int Consumation { get; protected set; }
            public int Time_landing { get; protected set; }
            public int Capacity { get; protected set; }
            public int Passangers { get; protected set; }
            public double Current_Fuel { get; set; }
            public Plane(string name, int weight, int consumation, int time_landing, int capacity, int passangers, double current_fuel)
            {
                Name = name;
                Weight = weight;
                Consumation = consumation;
                Time_landing = time_landing;
                Capacity = capacity;
                Passangers = passangers;
                Current_Fuel = current_fuel;
            }


            public class Boeing737 : Plane
            {
                public Boeing737(string name, int weight, int consumation, int time_landing, int capacity, int passangers, double current_fuel)
                    : base(name, weight, consumation, time_landing, capacity, passangers, current_fuel)
                {
                }
            }

            public class Boeing747 : Plane
            {
                public Boeing747(string name, int weight, int consumation, int time_landing, int capacity, int passangers, double current_fuel)
                    : base(name, weight, consumation, time_landing, capacity, passangers, current_fuel)
                {
                }
            }


            public class CanadairCRJ700 : Plane
            {
                public CanadairCRJ700(string name, int weight, int consumation, int time_landing, int capacity, int passangers, double current_fuel)
                    : base(name, weight, consumation, time_landing, capacity, passangers, current_fuel)
                {
                }
            }

            public class Cessna560XL : Plane
            {
                public Cessna560XL(string name, int weight, int consumation, int time_landing, int capacity, int passangers, double current_fuel)
                    : base(name, weight, consumation, time_landing, capacity, passangers, current_fuel)
                {
                }
            }

        }
    }
}
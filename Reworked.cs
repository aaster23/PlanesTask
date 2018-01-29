using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        public static int planeidcounter = 0;
        public static List<Airplane> Airplanes = new List<Airplane>();
        public static double SpellCheck(string dirty)
        {
            while (String.IsNullOrWhiteSpace(dirty))
            {
                Console.WriteLine("Въведете нещо, хора сме все пак!");
                dirty = Console.ReadLine();
            }

            string clear = "";
            foreach (char ch in dirty)
            {
                if (Char.IsDigit(ch))
                {
                    clear = clear + ch;
                }
            }

            if (clear == "")
                return 0;
            return double.Parse(clear);
        }

        static void PlanesInitializer(double planes, string planetype)
        {
            for (int i = 0; i < planes; i++)
            {
                switch (planetype)
                {
                     case "Boeing737":
                        Console.WriteLine("Колко гориво има в самолет {0} ", (planeidcounter + 1));
                        Airplanes.Add(new Boeing737(planeid: planeidcounter++, currentfuel: SpellCheck(Console.ReadLine())));
                        Airplanes[planeidcounter - 1].FuelCheck();
                     break;

                     case "Boeing747":
                        Console.WriteLine("Колко гориво има в самолет {0} ", (planeidcounter + 1));
                        Airplanes.Add(new Boeing747(planeid: planeidcounter++, currentfuel: SpellCheck(Console.ReadLine())));
                        Airplanes[planeidcounter - 1].FuelCheck();
                        break;

                     case "CanadairCRJ700":
                        Console.WriteLine("Колко гориво има в самолет {0} ", (planeidcounter + 1));
                        Airplanes.Add(new CanadairCRJ700(planeid: planeidcounter++, currentfuel: SpellCheck(Console.ReadLine())));
                        Airplanes[planeidcounter - 1].FuelCheck();
                        break;

                     case "Cessna560XL":
                        Console.WriteLine("Колко гориво има в самолет {0} ", (planeidcounter + 1));
                        Airplanes.Add(new Cessna560XL(planeid: planeidcounter++, currentfuel: SpellCheck(Console.ReadLine())));
                        Airplanes[planeidcounter - 1].FuelCheck();
                        break;
                }
            }
        }

        static double PlaneType(string planetype)
        {
            Console.WriteLine("Колко самолета тип {0} има във въздуха?", planetype);
            double planes = SpellCheck(Console.ReadLine());
            return planes;
        }

        static void LandingTower()
        {
            int airplanesTotal = Airplanes.Count;
            for (int i = 0; i < airplanesTotal; i++)
            {
                Airplanes = Airplanes.OrderBy(x => x.CurrentFuel).ToList();
                for (int u = 0; u < airplanesTotal; u++)
                {
                    if (Airplanes[0].CurrentFuel < Airplanes[0].FuelCapacity / 10)
                    {
                        Console.WriteLine("Самолет {0} - {1} се насочи към друго летище, защото има по-малко от 10% от макс. гориво ({2:0.00}, от макс {3})", Airplanes[0].AirplaneName, Airplanes[0].PlaneID, Airplanes[0].PlaneID, Airplanes[0].FuelCapacity);
                        Airplanes.Remove(Airplanes[0]);
                        airplanesTotal--;
                    }
                }
                Console.WriteLine(Airplanes[0].AirplaneName + " - " + Airplanes[0].PlaneID + "каца, защото има {0:0.00} гориво", Airplanes[0].CurrentFuel);
                foreach (Airplane planeinscope in Airplanes)
                {
                    planeinscope.FuelCalculation(Airplanes[0].TimeLanding);
                }
                Airplanes.Remove(Airplanes[0]);

            }
        }

        static void Main(string[] args)
        {

            string planetype = "Boeing737";
            double planes = PlaneType(planetype);
            PlanesInitializer(planes, planetype);

            planetype = "Boeing747";
            planes = PlaneType(planetype);
            PlanesInitializer(planes, planetype);

            planetype = "CanadairCRJ700";
            planes = PlaneType(planetype);
            PlanesInitializer(planes, planetype);

            planetype = "Cessna560XL";
            planes = PlaneType(planetype);
            PlanesInitializer(planes, planetype);

            LandingTower();

            Console.ReadKey();

            Environment.Exit(1);
        }

    }
    public class Airplane
    {
        public string AirplaneName { get; protected set; }
        public int AirplaneWeight { get; protected set; }
        public int AirplaneConsumption { get; protected set; }
        public int TimeLanding { get; protected set; }
        public int FuelCapacity { get; protected set; }
        public int Passangers { get; protected set; }
        public double CurrentFuel { get; protected set; }
        public int PlaneID { get; protected set; }
        public Airplane(string airplanename, int planeid, int airplaneweight, int airplaneconsumption, int timelanding, int fuelcapacity, int passangers, double currentfuel)
        {
            AirplaneName = airplanename;
            AirplaneWeight = airplaneweight;
            AirplaneConsumption = airplaneconsumption;
            TimeLanding = timelanding;
            FuelCapacity = fuelcapacity;
            Passangers = passangers;
            PlaneID = planeid;
            CurrentFuel = currentfuel;
        }

        public void FuelCalculation(int landing)
        {
            CurrentFuel = CurrentFuel - (CurrentFuel * landing / 60);
        }

        public void FuelCheck()
        {
            while (CurrentFuel > FuelCapacity || CurrentFuel < FuelCapacity/15)
            {
                Console.WriteLine("Въведеното гориво е извън границите, моля въведете между 150 и {0}", FuelCapacity);
                CurrentFuel = Program.SpellCheck(Console.ReadLine());
            }          
        }
    }

    class Boeing737 : Airplane
    {

        public Boeing737(string airplanename = "Boeing737" , int planeid = 0, int airplaneweight = 12400, int airplaneconsumption = 75, int timelanding = 3, int fuelcapacity = 1600, int passangers = 270, double currentfuel = 0) 
            : base(airplanename, planeid, airplaneweight, airplaneconsumption, timelanding, fuelcapacity, passangers, currentfuel)
        {
        }
    }
    
    class Boeing747 : Airplane
    {

        public Boeing747(string airplanename = "Boeing747", int planeid = 0, int airplaneweight = 16100, int airplaneconsumption = 175, int timelanding = 5, int fuelcapacity = 2200, int passangers = 350, double currentfuel = 0) 
            : base(airplanename, planeid, airplaneweight, airplaneconsumption, timelanding, fuelcapacity, passangers, currentfuel)
        {
        }
    }
    class CanadairCRJ700 : Airplane
    {

        public CanadairCRJ700(string airplanename = "Canadair CRJ700", int planeid = 0, int airplaneweight = 9000, int airplaneconsumption = 55, int timelanding = 4, int fuelcapacity = 950, int passangers = 70, double currentfuel = 0) 
            : base(airplanename, planeid, airplaneweight, airplaneconsumption, timelanding, fuelcapacity, passangers, currentfuel)
        {
        }
    }

    class Cessna560XL : Airplane
    {

        public Cessna560XL(string airplanename = "Cessna 560XL", int planeid = 0, int airplaneweight = 4500, int airplaneconsumption = 30, int timelanding = 2, int fuelcapacity = 700, int passangers = 8, double currentfuel = 0) 
            : base(airplanename, planeid, airplaneweight, airplaneconsumption, timelanding, fuelcapacity, passangers, currentfuel)
        {
        }
    }


}

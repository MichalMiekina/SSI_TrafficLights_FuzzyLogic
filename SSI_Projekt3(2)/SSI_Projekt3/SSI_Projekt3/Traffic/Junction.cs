using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SSI_Projekt3.Traffic
{
    class Junction
    {
        public List<Intersection> Intersections { get; set; } = new List<Intersection>();
        public int TurnNumber { get; set; } = 0;
        public int TurnTime { get; set; } = 0;

        public Junction(int intersections, int lanes,params double[] density)
        {
            int whichLane = 0;
            for(int i = 0; i < intersections; i++)
            {
                Intersections.Add(new Intersection());
                for (int j = 0; j < lanes; j++)
                {
                    Intersections[i].Lanes.Add(new Lane());
                    Intersections[i].Lanes[^1].Density = density[whichLane];
                    whichLane++;
                }
            }
            Intersections[0].GreenLight = true;
        }

        public void SimulateTurn()
        {
            TurnNumber++;
            
            Console.WriteLine("Turn: " + TurnNumber);

            for(int i = 0; i < Intersections.Count; i++)
            {
                for(int j = 0; j < Intersections[i].Lanes.Count; j++)
                {
                    Console.WriteLine("Number of cars at " + (i + 1) + ". intersection and " + (j + 1) + ". lane: " + Intersections[i].Lanes[j].CarsAmount);
                }
            }
            DoTraffic();
            ChangeLights();

        }

        public void ChangeLights()
        {
            if (Intersections[0].GreenLight == false)
            {

                Intersections[0].GreenLight = true;
                Intersections[1].GreenLight = false;
                TurnTime = Intersections[0].GreenTime;
                for(int i = 0; i < Intersections[0].Lanes.Count; i++)
                {
                    if(TurnTime/2 > Intersections[0].Lanes[i].CarsAmount)
                    {
                        Intersections[0].Lanes[i].CarsAmount = 0;
                    }
                    else
                    {
                        Intersections[0].Lanes[i].CarsAmount -= TurnTime / 2;
                    }
                    
                    Console.WriteLine("At 1. intersection, " + (i + 1) + ". lane, " + (TurnTime / 2) + " cars were able to leave the junction.");
                    //Console.WriteLine("At 2. intersection, " + (i + 1) + ". lane, 0 cars left the junction.");
                }

            }
            else
            {
                Intersections[0].GreenLight = false;
                Intersections[1].GreenLight = true;
                TurnTime = Intersections[1].GreenTime;
                for (int i = 0; i < Intersections[1].Lanes.Count; i++)
                {
                    if (TurnTime / 2 > Intersections[1].Lanes[i].CarsAmount)
                    {
                        Intersections[1].Lanes[i].CarsAmount = 0;
                    }
                    else
                    {
                        Intersections[1].Lanes[i].CarsAmount -= TurnTime / 2;
                    }
                    //Console.WriteLine("At 1. intersection, " + (i + 1) + ". lane, 0 cars left the junction.");
                    Console.WriteLine("At 2. intersection, " + (i + 1) + ". lane, " + (TurnTime / 2) + " cars were able to leave the junction.");
                    
                }

            }
        }

        public void DoTraffic()
        {
            Console.WriteLine(Intersections[0].GreenTime + "kupa" + Intersections[1].GreenTime);
            Console.WriteLine();
            var Rnd = new Random();

            for (int i = 0; i < Intersections.Count; i++)
            {
                for (int j = 0; j < Intersections[i].Lanes.Count; j++)
                {
                    // gęstość uczęszczania aut na danym pasie według danych wprowadzonych na początku programu, np przez system zliczający przez detektory
                    Console.WriteLine("Number of cars at " + (i + 1) + ". Intersection and " + (j + 1) + ". Lane: " + (Intersections[i].Lanes[j].CarsAmount += Convert.ToInt32(Math.Round(TurnTime / Intersections[i].Lanes[j].Density))));


                                        // częstość aut na danym pasie wybierana w sposób bardziej losowy
                    //if (i == 1)
                    //{
                    //    Console.WriteLine("Number of cars at " + (i + 1) + ". Intersection and " + (j + 1) + ". Lane: " + (Intersections[i].Lanes[j].CarsAmount += Rnd.Next(Convert.ToInt32(Math.Round(TurnTime / 10.1)), Convert.ToInt32(Math.Round(TurnTime / 6.3)))));

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Number of cars at " + (i + 1) + ". Intersection and " + (j + 1) + ". Lane: " + (Intersections[i].Lanes[j].CarsAmount += Rnd.Next(Convert.ToInt32(Math.Round(TurnTime / 5.5)), Convert.ToInt32(Math.Round(TurnTime / 2.0)))));

                    //}
                }
            }
        }


    }
}

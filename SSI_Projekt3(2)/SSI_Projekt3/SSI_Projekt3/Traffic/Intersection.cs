using System;
using System.Collections.Generic;
using System.Text;

namespace SSI_Projekt3.Traffic
{
    class Intersection
    {
        public List<Lane> Lanes { get; set; } = new List<Lane>();
        //public Lane[] Lanes { get; set; } = new Lane[2];
        public bool GreenLight { get; set; } 
        public int GreenTime { get; set; } 
        public Intersection()
        {
            GreenTime = 30;
            GreenLight = false;
        }

        public void TurnGreenOn()
        {
            
            for(int i = 0; i < Lanes.Count; i++)
            {
                Console.WriteLine("In total, amount of cars in this turn equals: "+Lanes[i].CarsAmount);
                Lanes[i].CarsAmount = Lanes[i].CarsAmount - GreenTime / 2;
                Console.WriteLine("After this turn, amount of cars is: " + Lanes[i].CarsAmount);
            }
        }

        public void TurnRedOn()
        {
            for (int i = 0; i < Lanes.Count; i++)
            {
                Console.WriteLine("In total, amount of cars in this turn equals: " + Lanes[i].CarsAmount);
                Lanes[i].CarsAmount = Lanes[i].CarsAmount - GreenTime / 2;
                Console.WriteLine("After this turn, amount of cars is: " + Lanes[i].CarsAmount);
            }
        }
    }
}

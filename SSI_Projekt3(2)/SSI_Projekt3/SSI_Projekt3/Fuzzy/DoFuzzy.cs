using System;
using SSI_Projekt3.Traffic;
using System.Collections.Generic;
using System.Text;

namespace SSI_Projekt3.Fuzzy
{
    class DoFuzzy
    {
        public List<double> MaxCarsNumbers { get; set; } = new List<double>();
        public double AverageMaxs { get; set; } = 0;


        public DoFuzzy(Junction jun)
        {
            // zeby poprawic czas swiatel, musimy porownac maksymalne wartosci liczby aut na pasach poszczegolnych ulic
            for (int i = 0; i < jun.Intersections.Count; i++)
            {
                MaxCarsNumbers.Add(jun.Intersections[i].Lanes[0].CarsAmount);
                
                for (int j = 1; j < jun.Intersections[i].Lanes.Count; j++)
                {
                    if (MaxCarsNumbers[i] < jun.Intersections[i].Lanes[j].CarsAmount)
                        MaxCarsNumbers[i] = jun.Intersections[i].Lanes[j].CarsAmount;
                }
                if (MaxCarsNumbers[i] == 0)
                    MaxCarsNumbers[i]++;
            }

            for (int i = 0; i < MaxCarsNumbers.Count; i++)
            {
                AverageMaxs += MaxCarsNumbers[i];
            }
            AverageMaxs /= MaxCarsNumbers.Count;
        }

        public void CorrectTrafficLightsConfig(Junction jun)
        {
            // kontrola czasu wyświetlania świateł, redukcja o 20% wszystkich z nich jeśli któryś przekracza minutę
            for(int i = 0; i < jun.Intersections.Count; i++)
            {
                if (jun.Intersections[i].GreenTime > 60)
                {
                    for (int j = 0; j < jun.Intersections.Count; j++)
                    {
                        jun.Intersections[i].GreenTime=Convert.ToInt32(Math.Round(jun.Intersections[i].GreenTime * 0.8));
                    }
                }
            }
            
            
            for(int i = 0; i < jun.Intersections.Count; i++)
            {
                Console.WriteLine(MaxCarsNumbers[i] + " " + AverageMaxs);
                jun.Intersections[i].GreenTime = Convert.ToInt32(Math.Round(MaxCarsNumbers[i] / AverageMaxs * jun.Intersections[i].GreenTime));
            }


        }

    }
}

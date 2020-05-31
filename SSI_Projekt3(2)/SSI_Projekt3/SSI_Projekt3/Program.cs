using System;
using SSI_Projekt3.Traffic;
using SSI_Projekt3.Fuzzy;
using System.IO;
using System.Runtime.CompilerServices;

namespace SSI_Projekt3
{
    class Program
    {
        static void Main(string[] args)
        {
            Junction Rzgowska_x_Dachowa = new Junction(2,3,5,4,7,7);

            string choice;
            short FuzzyActivationCounter = 1;

            // symulacja nieskonczona

            //while (true)
            //{
            //    if (FuzzyActivationCounter % 3 == 0)
            //    {
            //        FuzzyActivationCounter = 0;
            //    }
            //    Rzgowska_x_Dachowa.SimulateTurn();
            //    FuzzyActivationCounter++;
            //}




            // symulacja 

            //for(int i = 0; i < 100; i++)
            //{
            //    if (FuzzyActivationCounter % 3 == 0)
            //    {
            //        FuzzyActivationCounter = 0;
            //    }
            //    Rzgowska_x_Dachowa.SimulateTurn();
            //    FuzzyActivationCounter++;
            //}





            // symulacja z recznym sterowaniem kazdej kolejki

            do
            {
                if (FuzzyActivationCounter % 6 == 0)
                {
                    FuzzyActivationCounter = 0;
                    DoFuzzy DoFuzzyOn = new DoFuzzy(Rzgowska_x_Dachowa);
                    DoFuzzyOn.CorrectTrafficLightsConfig(Rzgowska_x_Dachowa);
                }
                Rzgowska_x_Dachowa.SimulateTurn();
                FuzzyActivationCounter++;

                Console.Write("Would you like to watch next turn(Y/N)?: ");
                choice = Console.ReadLine();
            } while (choice == "Y" || choice == "y");
        }
    }
}

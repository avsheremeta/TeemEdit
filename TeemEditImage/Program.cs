using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeemEditImage
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                //save count of teem
                int countCrew = Person.TeemCount();

                // save personal speeds of employees 
                int[] speedPersons = Person.SpeedEmployees(countCrew);
                Console.WriteLine();

                // save total number of pictures 
                int allImages = Person.CountImages();
                Console.WriteLine();

                //show personal speed
                for (int i = 0; i < speedPersons.Length; i++)
                {
                    Console.WriteLine("Speed Person № {0} is: {1} ", i + 1, speedPersons[i]);
                }
                Console.WriteLine();

                //show personal work and total time
                var tuple = Person.CalcImagesAndWork(allImages, speedPersons);

                //show total time
                Console.WriteLine("Totoal time working is: " + tuple.Item1 + " minutes \n");

                //show personal productivity 
                for (int i = 0; i < tuple.Item2.Length; i++)
                {
                    Console.WriteLine("Person {0} edit: {1} images ", i + 1, tuple.Item2[i]);
                }
                Console.WriteLine();


                Console.Write("Press ESC to exit. To continue, press ENTER");

                key = Console.ReadKey();
               
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }               
            }
        }
    }
}

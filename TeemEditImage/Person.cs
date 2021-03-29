using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeemEditImage
{
    public class Person
    {
        //for check and store the number of people in the team 
        public static int TeemCount()
        {
            int countCrew = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter the number of team members: ");
                    countCrew = Int32.Parse(Console.ReadLine());

                    if (countCrew > 0)
                        break;
                    Console.WriteLine("The number of people in the teem must be greater than zero. Enter an integer greater than zero   ");
                }
                catch
                {
                    Console.WriteLine("Incorrect input format, enter an integer greater than zero ");
                }
            }
            return countCrew;
        }

        //for check and store personal speeds of team members 
        public static int[] SpeedEmployees(int arrlengs)
        {
            int[] speedPersons = new int[arrlengs];
            for (int i = 0; i < speedPersons.Length; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the personal speed of the {0} employee: ", i + 1);
                        int input = Int32.Parse(Console.ReadLine());
                        if (input > 0)
                        {
                            speedPersons[i] = input;
                            break;
                        }
                        else
                        { Console.WriteLine("The speed must be greater than zero"); }
                    }
                    catch
                    { Console.WriteLine("Incorrect input format, enter an integer greater than zero"); }
                }
            }
            return speedPersons;
        }

        //for check and store the number of image
        public static int CountImages()
        {
            int allImages = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter the number of pictures to edit: ");
                    allImages = Int32.Parse(Console.ReadLine());
                    if (allImages > 0)
                        break;
                    Console.WriteLine("The number of pictures must be greater than zero. Enter an integer greater than zero   ");
                }
                catch
                {
                    Console.WriteLine("Incorrect input format, enter an integer greater than zero");
                }
            }
            return allImages;
        }

        //count personal work and total working time 
        public static Tuple<int, int[]> CalcImagesAndWork(int images, int[] arrSpeed)
        {          
            int totalTime = 1;

            //save personal work 
            int[] personalWork = new int[arrSpeed.Length];

            //find out work to each worker when photos less than employees 
            int[] tempWork = (int[])arrSpeed.Clone();

            // for find out total time
            int[] sortWorkersBySpeed = (int[])arrSpeed.Clone();
            Array.Sort(sortWorkersBySpeed);

            //save personal time work
            int[] personal_time = (int[])arrSpeed.Clone();

            // images as many as employees 
            if (images == arrSpeed.Length)
            {
                totalTime = sortWorkersBySpeed[images - 1];

                for (int i = 0; i < images; i++)
                {
                    personalWork[i] += 1;
                }
            }

            // images less than employees 
            if (images < arrSpeed.Length)
            {
                totalTime = sortWorkersBySpeed[images - 1];
                for (int i = 0; i < sortWorkersBySpeed.Length; i++)
                {
                    for (int j = 0; j < tempWork.Length; j++)
                    {
                        if (sortWorkersBySpeed[i] == tempWork[j] & images != 0)
                        {
                            int numIdx = Array.IndexOf(tempWork, tempWork[j]);
                            personalWork[numIdx] = 1;
                            tempWork[j] = 0;
                            images--;
                        }
                    }
                }
            }

            // images more than employees           
            if (images > arrSpeed.Length)
            {
                //at first everyone takes one photo
                for (int i = 0; i < sortWorkersBySpeed.Length; i++)
                {
                    personalWork[i] += 1;
                }
                images = images - sortWorkersBySpeed.Length;

                //for the remaining photos 
                while (images > 0)
                {
                    for (int i = 0; i < arrSpeed.Length; i++)
                    {
                        //the photo is edited by someone who has already done the previous work if there are free photos 
                        if (images != 0 & (totalTime % arrSpeed[i] == 0))
                        {
                            personalWork[i] += 1;
                            images--;
                            personal_time[i] += arrSpeed[i];
                        }                       
                    }
                    if (images == 0)
                        break;
                    else
                        totalTime++;
                }
                totalTime = personal_time.Max();  
            }
          
            return Tuple.Create(totalTime, personalWork);
          
        }
    }
}

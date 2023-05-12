using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Probability_Assingment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the size of your set of data:");
            int size = int.Parse(Console.ReadLine());
            double[] nums = new double[size];

            if (nums == null || nums.Length == 0 || size < 3)
                throw new ArgumentException("Not enough data to work on.");

            for (int i = 0; i < nums.Length; i++) 
            {
                Console.WriteLine($"Element {i+1}:");
                nums[i]= double.Parse(Console.ReadLine());

            }
            Array.Sort(nums);

            Display(nums);
            

        }












        public static double Q1(double[] nums)
        {

            double Q1, ans = 0.25 * (nums.Length+1);
            if ((ans * 2) % 2 != 0)
            {
                int ans2 = Convert.ToInt32(ans);
                Q1 = (nums[ans2 - 1] + nums[ans2]) / 2;

            }
            else
            {

                Q1 = (nums[((int)ans) - 1] );

            }
            return Q1;

        }


        public static double Median(double[] nums)
        {
             
            double median ,  ans = 0.5 * (nums.Length + 1);
            if ((ans * 2) % 2 != 0)
            {
                int ans2 = Convert.ToInt32(ans);
                median = (nums[ans2 - 1] + nums[ans2]) / 2;

            }
            else
            {

                median = (nums[((int)ans) - 1]);

            }
            return median;

        }



        public static double Q3(double[] nums)
        {

            double Q3, ans = 0.75 * (nums.Length + 1);
            if ((ans * 2) % 2 != 0)
            {
                int ans2 = Convert.ToInt32(ans);
                Q3 = (nums[ans2 - 2] + nums[ans2-1]) / 2;

            }
            else
            {

                Q3 = (nums[((int)ans) - 1]);

            }

            return Q3;

        }


        public static void Mode(double[] nums)
        {
            int counter = 0, maxTillNow = 0;
            double modeValue=0;
            double[] nums2 = new double[nums.Length];
            Array.Copy(nums , nums2 , nums.Length);


            for(int i = 0; i < nums.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] == nums2[j])
                    {
                        counter++;
                    }
                    if (counter >= 2)
                    {
                        if (counter > maxTillNow)
                        {
                            maxTillNow = counter;
                            modeValue = nums[i];
                        }
                    }
                    

                }
            }

            if (maxTillNow >= 2)
            {
                Console.WriteLine($"The mode of your data set is {modeValue} and it occured {maxTillNow} times in the data.");
        
            }
            else
            {
                Console.WriteLine("There is no mode for this data.");
             
            }

            
        }


        public static double Range(double[] nums)
        {
            double max = nums[0], min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];

                }
                else if (nums[i] < min)
                {
                    min = nums[i];

                }
                else
                {
                    continue;
                }
                    

            }
            
            
            
            return max - min;
        }


        public static double P90(double[] nums) 
        {

            double P90, ans = 0.9 * nums.Length;
            if ((ans * 2) % 2 != 0)
            {
                Math.Ceiling(ans);
                P90 = (nums[(int)ans]);

            }
            else
            {

                P90 = (nums[((int)ans) - 1] + nums[(int)ans]) / 2;

            }

            return P90;
        }

        public static void Outliers(double[] nums)
        {
            double[] outliers = new double[nums.Length];
            double lowerBoundary = (Q1(nums) - (1.5 * (Q3(nums) - Q1(nums))));
            double upperBoundary = (Q3(nums) + (1.5 * (Q3(nums) - Q1(nums))));
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < lowerBoundary || nums[i] > upperBoundary)
                {
                    outliers[i] = nums[i];
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine($"Lower boundary: {lowerBoundary}");
            Console.WriteLine($"Upper boundary: {upperBoundary}");
            Console.WriteLine();
           
                
                for (int i = 0; i < nums.Length; i++)
                {
                    if (outliers[i] >0)
                    {
                    Console.WriteLine($"Outlier: {outliers[i]}");
                    }
        
                }
                
      

        }

        public static void Display(double[] nums)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Q1: {Q1(nums)}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Median: {Median(nums)}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Q3: {Q3(nums)}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"IQR: {Q3(nums)-Q1(nums)}");
            Console.WriteLine("--------------------------------");
            Mode(nums);
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Range: {Range(nums)}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"90th Percentile: {P90(nums)}");
            Console.WriteLine("--------------------------------");
            Outliers(nums);
            
        }



    }
}

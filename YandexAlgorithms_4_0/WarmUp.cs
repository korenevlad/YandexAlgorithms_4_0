using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace YandexAlgorithms_4_0
{
    public class WarmUp
    {

        delegate int CheckDelegate(int medium, int m, int a, int b, int c, int d);
        public static void A_Solution(string a, string b)
        {
            int[] nm = a.Split(' ').Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];
            int[] nums = b.Split(' ').Select(int.Parse).ToArray();
            List<int> results = new List<int>();
            for (int i = 0; i < m; i++)
            {
                int[] lr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int l = lr[0];
                int r = lr[1];
                int minInd = l;
                int min = nums[minInd];
                int minPlus = min;
                for (int j = l; j <= r; j++)
                {
                    if (nums[j] < min)
                    {
                        min = nums[j];
                        minInd = j;
                    }
                    if (nums[j] > min)
                    {
                        minPlus = nums[j];
                    }
                }
                if (minPlus == min)
                {
                    results.Add(2147483647);
                }
                else
                {
                    results.Add(minPlus);
                }
            }
            foreach (var k in results)
            {
                if (k == 2147483647)
                {
                    Console.WriteLine("NOT FOUND");
                }
                else
                {
                    Console.WriteLine(k);
                }
            }
        }

        public static decimal C_Solution(string a)
        {
            int[] coordinates = a.Split(" ").Select(int.Parse).ToArray();
            int xa = coordinates[0];
            int ya = coordinates[1];
            int xb = coordinates[2];
            int yb = coordinates[3];

            decimal resultEasyWay = EasyWay(xa, ya, xb, yb);
            decimal resultHardWay = HardWay(xa, ya, xb, yb);

            return Math.Min(resultEasyWay, resultHardWay);

            decimal EasyWay(int xa, int ya, int xb, int yb)
            {
                decimal rA = (decimal)Math.Sqrt(Math.Pow(xa, 2) + Math.Pow(ya, 2));
                decimal rB = (decimal)Math.Sqrt(Math.Pow(xb, 2) + Math.Pow(yb, 2));
                decimal result = rA + rB;
                return result;
            }

            decimal HardWay(int xa, int ya, int xb, int yb)
            {
                decimal rA = (decimal)Math.Sqrt(Math.Pow(xa, 2) + Math.Pow(ya, 2));
                decimal rB = (decimal)Math.Sqrt(Math.Pow(xb, 2) + Math.Pow(yb, 2));

                int xMin = 0;
                int yMin = 0;
                int xMax = 0;
                int yMax = 0;
                decimal minRadius = 0;
                decimal maxRadius = 0;

                if (rA <= rB)
                {
                    minRadius = rA;
                    xMin = xa;
                    yMin = ya;

                    maxRadius = rB;
                    xMax = xb;
                    yMax = yb;
                }
                else{
                    minRadius = rB;
                    xMin = xb;
                    yMin = yb;

                    maxRadius = rA;
                    xMax = xa;
                    yMax = ya;
                }

                decimal firstPart = maxRadius - minRadius;

                decimal minCorner = (decimal)Math.Atan2(yMin, xMin);
                decimal maxCorner = (decimal)Math.Atan2(yMax,xMax);

                decimal angleDifference = maxCorner - minCorner;
                angleDifference = Math.Abs((angleDifference + (decimal)Math.PI) % (2 * (decimal)Math.PI) - (decimal)Math.PI);

                decimal secondPart = angleDifference * minRadius;

                decimal result = firstPart + secondPart;
                return result;
            }
        }

        public static void D_Solution(string a, string b)
        {
            char[] numsA = a.ToCharArray();
            char[] numsB = b.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < numsA.Length; i++)
            {
                if (!dict.ContainsKey(numsA[i]))
                {
                    dict[numsA[i]] = 1;
                }
                else
                {
                    dict[numsA[i]]++;
                }
            }
            for (int i = 0; i < numsB.Length; i++)
            {
                if (dict.ContainsKey(numsB[i]))
                {
                    dict[numsB[i]]--;
                }
            }
            List<int> results = dict.Values.ToList();
            bool flag = true;
            foreach (var i in results)
            {
                if (i != 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public static void E_Solution(string a, string b)
        {
            int.TryParse(a, out int n);
            int[] nums = b.Split(' ').Select(int.Parse).ToArray();
            int sum = 0;
            List<int> results = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum += Math.Abs(nums[i] - nums[0]);
            }
            results.Add(sum);
            for (int i = 1; i < nums.Length; i++)
            {
                int tempSumLeft = (nums[i] - nums[i - 1]) * i;
                int tempSumRight = (nums[i] - nums[i - 1]) * (nums.Length - i);
                sum = sum + tempSumLeft - tempSumRight;
                results.Add(sum);
            }
            for (int i = 0; i < results.Count; i++)
            {
                Console.Write(results[i]);
                if (i != results.Count - 1)
                {
                    Console.Write(" ");
                }
            }
        }

        public static void F_Solution(string a, string b)
        {
            int.TryParse(a, out int k);
            int.TryParse(b, out int n);
            int[] floors = new int[n];
            for (int i = 0; i < n; i++)
            {
                int.TryParse(Console.ReadLine(), out int floor);
                floors[i] = floor;
            }

            int ptr = 0;
            for (int i = floors.Length - 1; i > 0; i--)
            {
                if (floors[i] != 0)
                {
                    ptr = i;
                    break;
                }
            }

            int sumTime = 0;
            while (ptr >= 0)
            {
                int countPerson = 0;
                sumTime += 2 * (ptr + 1);
                for (int i = ptr; i >= 0; i--)
                {
                    bool flag = false;
                    bool flagZero = false;
                    if (countPerson < k && (k - countPerson) < floors[i])// если лифт не заполнен и свободных мест в лифте меньше чем на этаже
                    {
                        int dif = k - countPerson;
                        countPerson += dif;
                        floors[i] = floors[i] - dif;
                        flag = true;
                    }
                    if (countPerson < k && (k - countPerson) >= floors[i] && flag == false && floors[i]!=0)// если лифт не заполнен, но на этаже можно забрать всех
                    {
                        countPerson += floors[i];
                        floors[i] = 0;
                        flagZero = true;
                    }
                    if (flagZero == true)
                    {
                        if (i == 0)
                        {
                            ptr = -1;
                        }
                        else
                        {
                            int j = i - 1;
                            while (j != -1 && floors[j] == 0)
                            {
                                if (j != 0)
                                {
                                    j--;
                                }
                                else
                                {
                                    j = -1;
                                }
                            }
                            ptr = j;
                        }
                    }
                }
            }
            Console.WriteLine(sumTime);
        }

        public static void Main(string[] args)
        {
            //A_Solution(Console.ReadLine(),Console.ReadLine());

            //Console.WriteLine(C_Solution(Console.ReadLine()));

            //D_Solution(Console.ReadLine(), Console.ReadLine());

            //E_Solution(Console.ReadLine(), Console.ReadLine());

            F_Solution(Console.ReadLine(), Console.ReadLine());
        }
    }
}

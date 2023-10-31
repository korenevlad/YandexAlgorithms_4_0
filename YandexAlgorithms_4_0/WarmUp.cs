using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void Main(string[] args)
        {
            //A_Solution(Console.ReadLine(),Console.ReadLine());
            //D_Solution(Console.ReadLine(), Console.ReadLine());
            E_Solution(Console.ReadLine(), Console.ReadLine());
        }
    }
}

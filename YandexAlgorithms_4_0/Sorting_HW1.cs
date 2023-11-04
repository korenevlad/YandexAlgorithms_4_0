//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace YandexAlgorithms_4_0
//{
//    public class Sorting_HW1
//    {
//        public static void A_Solution_Partition(string a, string b, string c)
//        {
//            int.TryParse(a, out int n);
//            int[] nums = b.Split(' ').Select(int.Parse).ToArray();
//            int.TryParse(c, out int predicat);

//            Partition(predicat, nums, nums[0], nums[nums.Length - 1]);

//            int Partition(int predicat, int[] nums, int left, int right)
//            {
//                int pivot = predicat;
//                int lPtr = left + 1;
//                int rPtr = right;

//                while (true)
//                {
//                    while (lPtr <= rPtr && nums[lPtr] <= pivot)
//                        lPtr++;

//                    while (lPtr <= rPtr && nums[rPtr] >= pivot)
//                        rPtr--;

//                    if (lPtr <= rPtr)
//                    {
//                        int temp = nums[lPtr];
//                        nums[lPtr] = nums[rPtr];
//                        nums[rPtr] = temp;
//                    }
//                    else
//                    {
//                        int temp2 = nums[left];
//                        nums[left] = nums[rPtr];
//                        nums[rPtr] = temp2;
//                        return rPtr;
//                    }
//                }
//            }
//        }

//        public static void Main(string[] args)
//        {
//            A_Solution_Partition(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
//        }
//    }
//}

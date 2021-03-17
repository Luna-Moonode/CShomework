using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cshw2_1 
{
    internal class Program 
    {
        private static bool IsPrime(int n) 
        {
            /**
             * 判断n是否为素数
             */
            var flag = true;
            var m = n;
            for (var i = 2; i < m; i++) 
            {
                if (n % i == 0 && n != 1 && n != 2)
                {
                    flag = false;
                    break;
                }
                m = n / i;
            }
            return flag;
        }
        
        private static ArrayList FindPrimeDivisor(int n)
        {
            /**
             * 找到n的所有素数因子
             */
            var arr = new ArrayList();
            for (var i = 2; i <= n; i++)
            {
                if (!IsPrime(i)) continue;
                if (n % i == 0)
                {
                    arr.Add(i);
                    n /= i;
                }
            }
            return arr;
        }
        
        private static ArrayList FindPrime(int n)
        {
            /**
             * 利用埃氏筛法找到小于n的所有素数
             */
            var ret = new ArrayList();
            var arr = new ArrayList(n);
            for (var i = 2; i < n; i++)
            {
                arr.Add(i);
            }
            for (var i = 0; i < arr.Count; i++)
            {
                var num = (int)arr[i];
                ret.Add(num);
                var time = 2;
                var checknum = num * time;
                while (checknum < n)
                {
                    arr.Remove(checknum);
                    time++;
                    checknum = num * time;
                }
            }
            return ret;
        }

        private static bool IsTpls(int[,] arr)
        {
            /**
             * 判断是否为托普利茨矩阵
             */
            var flag = true;
            var row = arr.GetUpperBound(0);
            var column = arr.GetUpperBound(1);
            var nextRow = 1;
            var nextColumn = 1;
            for (var i = 0; i < row; i++)
            {
                var checkNum = arr[i, 0];
                while (nextRow <= row && nextColumn <= column)
                {
                    if (arr[nextRow, nextColumn] == checkNum)
                    {
                        nextRow++;
                        nextColumn++;
                        continue;
                    }
                    flag = false;
                    break;
                }
            }
            if (!flag) return flag;
            nextRow = 2;
            nextColumn = 1;
            for (var i = 1; i < column; i++)
            {
                var checkNum = arr[0, i];
                while (nextRow <= row && nextColumn <= column)
                {
                    if (arr[nextRow, nextColumn] == checkNum)
                    {
                        nextRow++;
                        nextColumn++;
                        continue;
                    }
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        
        private class MyArray
        {
            private ArrayList array;
            public MyArray(ArrayList arr) {
                array = arr;
            }
            public int Sum()
            {
                var sum = 0;
                foreach (var i in array) sum += (int)i;
                return sum;
            }
            
            public ArrayList Sort()
            {
                ArrayList arr = array;
                arr.Sort();
                return arr;
            }

            public int FindMax()
            {
                ArrayList arr = Sort();
                return (int)arr[arr.Count - 1];
            }
            
            public int FindMin()
            {
                ArrayList arr = Sort();
                return (int)arr[0];
            }

            public double Average()
            {
                return Sum() / (double)array.Count;
            }
        }
        
        public static void Main(string[] args) 
        {
//            找一个数的质数因子
            var num0 = 10;
            var arr0 = FindPrime(num0);
            foreach (var i in arr0)
            {
                Console.WriteLine(i);
            }
//            找10以内的质数
            var num = 10;
            var arr = FindPrime(num);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
//            判断是否为tpls
            int[,] arr1 = {
                {1, 2, 3},
                {2, 1, 2},
                {3, 2, 1}
            };
            Console.WriteLine(IsTpls(arr1));
            
//            数组方法
            var arr3 = new ArrayList(4);
            arr3.Add(3);
            arr3.Add(2);
            arr3.Add(1);
            arr3.Add(4);
            arr3.Sort();
            var myarr3 = new MyArray(arr3);
            Console.WriteLine(myarr3.Average());
            Console.WriteLine(myarr3.Sum());
            Console.WriteLine(myarr3.FindMax());
            Console.WriteLine(myarr3.FindMin());
        }
    }
}
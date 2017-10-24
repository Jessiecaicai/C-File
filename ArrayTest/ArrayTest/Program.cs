using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTest
{
    class Program
    {
        //对数组进行遍历
        public static Array ergodic(int[][,] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("Element({0}):", i);
                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {
                    Console.WriteLine("Element({0}{1}):", i, j);
                    for (int k = 0; k < jaggedArray[i].GetLength(1); k++)
                    {
                        Console.WriteLine(jaggedArray[i][j, k]);
                    }
                    
                }
            }
            //System.Console.Write("{0}", jaggedArray[0][1, 1]);
            Console.WriteLine();
            return jaggedArray;
 
        }
        //初始化方法
        public static Array init(int[][,] jaggedArray)
        {
            jaggedArray[0]=  new int[,]{ { 1, 1 }, { 1, 2 } };
            jaggedArray[1] = new int[,] { { 2, 1 }, { 2, 2 }, { 2, 3 } };
            jaggedArray[2] = new int[,] { { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 } };
            return jaggedArray;
        }

        static void Main(string[] args)
        {
            //Define the array
            int[][,] jaggedArray = new int[3][,];

            init(jaggedArray);
            ergodic(jaggedArray);

            Console.WriteLine("press any key to exit.");

            Console.ReadKey();
            
        }
    }
}

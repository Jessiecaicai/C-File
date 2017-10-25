using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AandBDrawer
{
    class Program
    {

        class Drawer
        {
            //字符三角形
            public void characterTriangle(int line, string value)
            {
                Console.WriteLine("字符三角形图象如下所示：");
                for (int i = 1; i <= line; i++)
                {
                    for (int j = 1; j <= line - i; j++)
                    {
                        Console.Write(" ");
                    }
                    int put = 2 * i - 1;
                    while (put > 0)
                    {
                        Console.Write("{0}", value);
                        put--;
                    }
                    Console.WriteLine();
                }
            }

            //背靠背字符三角形
            public void backCharacterTriangle(int line, string value)
            {
                Console.WriteLine("背靠背字符三角行图像如图所示");
                for (int i = 1; i <= line; i++)
                {
                    for (int j = 1; j <= line - i; j++)
                    {

                        Console.Write(" ");

                    }
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(value);
                    }
                    Console.Write(" ");
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(value);
                    }
                    Console.WriteLine();
                }
            }

            //字符菱形
            public void characterPrismatic(int line, string value)
            {
                Console.WriteLine("字符菱形图象如下所示（为了实现图像若输入偶数将自动减一处理）：");

                if (line % 2 == 0)
                {
                    line = line - 1;
                }
                int shortline = (line + 1) / 2;
                for (int i = 1; i <= shortline; i++)
                {
                    for (int j = 1; j <= shortline - i; j++)
                    {
                        Console.Write(" ");
                    }
                    int put = 2 * i - 1;
                    while (put > 0)
                    {
                        Console.Write("{0}", value);
                        put--;
                    }
                    Console.WriteLine();
                }

                for (int i = shortline + 1; i <= line; i++)
                {
                    int put = i - shortline;
                    while (put > 0)
                    {
                        Console.Write(" ");
                        put--;
                    }
                    int put2 = 2 * (line - i) + 1;
                    for (int j = 1; j <= put2; j++)
                    {
                        Console.Write("{0}", value);
                    }
                    Console.WriteLine();
                }
            }

            //交替字符倒三角行
            public void alternateInvertedTriangle(int line, string value)
            {
                Console.WriteLine("交替字符倒三角形图象如下所示：");
                for (int i = 1; i <= line; i++)
                {
                    for (int j = 1; j <= i - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    int judge = 1;
                    while (judge <= 2 * (line - i + 1) - 1)
                    {
                        if (judge % 2 == 1)
                            Console.Write(value.Substring(0, 1));
                        else
                            Console.Write(value.Substring(1, 1));
                        judge++;
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            //无限循环
            while (true)
            {
                //建立选择模式
                Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                Console.WriteLine("*******************************************");
                Console.WriteLine("1--字符三角形     2--背靠背字符三角形");
                Console.WriteLine("3--字符菱形       4--交替字符倒三角形");
                Console.WriteLine("*******************************************");
                int choose = Convert.ToInt32(Console.ReadLine());

                //字符三角形
                while (choose == 1)
                {
                    Console.WriteLine("请输入字符三角形的行数和值（每输入一个按Enter以继续)：");
                    try
                    {
                        int line = Convert.ToInt32(Console.ReadLine());
                        string value = Convert.ToString(Console.ReadLine());
                        Drawer drawer = new Drawer();
                        drawer.characterTriangle(line, value);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Exception caught: {0}", e);
                    }

                    Console.ReadKey();
                    break;
                }

                //背靠背字符三角形
                while (choose == 2)
                {
                    try
                    {
                        Console.WriteLine("请输入背靠背字符三角形的行数和值（每输入一个按Enter以继续)：");
                        int line = Convert.ToInt32(Console.ReadLine());
                        string value = Convert.ToString(Console.ReadLine());
                        Drawer drawer = new Drawer();
                        drawer.backCharacterTriangle(line, value);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Exception caught: {0}", e);
                    }
                    Console.ReadKey();
                    break;
                }

                //字符菱形
                while (choose == 3)
                {
                    try
                    {
                        Console.WriteLine("请输入字符菱形的行数和值（每输入一个按Enter以继续)：");
                        int line = Convert.ToInt32(Console.ReadLine());
                        string value = Convert.ToString(Console.ReadLine());
                        Drawer drawer = new Drawer();
                        drawer.characterPrismatic(line, value);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Exception caught: {0}", e);
                    }
                    Console.ReadKey();
                    break;
                }

                //交替字符倒三角行
                while (choose == 4)
                {
                    try
                    {
                        Console.WriteLine("请输入交替字符倒三角形的行数和值（每输入一个按Enter以继续)：");
                        int line = Convert.ToInt32(Console.ReadLine());
                        string value = Convert.ToString(Console.ReadLine());
                        Drawer drawer = new Drawer();
                        drawer.alternateInvertedTriangle(line, value);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Exception caught: {0}", e);
                    }
                    Console.ReadKey();
                    break;
                }

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace AandBDrawer
{
    class Program
    {

        class Drawer
        {
            //字符三角形
            public void characterTriangle(int line, string value, StreamWriter streamWriter)
            {
                Console.WriteLine("字符三角形图象如下所示：");
                streamWriter.WriteLine("字符三角形图象如下所示：");
                for (int i = 1; i <= line; i++)
                {
                    for (int j = 1; j <= line - i; j++)
                    {
                        Console.Write(" ");
                        streamWriter.Write(" ");
                    }
                    int put = 2 * i - 1;
                    while (put > 0)
                    {
                        Console.Write("{0}", value);
                        streamWriter.Write("{0}", value);
                        put--;
                    }
                    Console.WriteLine();
                    streamWriter.WriteLine();
                }
            }

            //背靠背字符三角形
            public void backCharacterTriangle(int line,string value, StreamWriter streamWriter)
            {
                Console.WriteLine("背靠背字符三角行图像如图所示");
                streamWriter.WriteLine("背靠背字符三角行图像如图所示");
                for (int i = 1; i <= line; i++)
                {
                    for(int j = 1; j <= line - i; j++)
                    {

                        Console.Write(" ");
                        streamWriter.Write(" ");

                    }
                    for(int k = 1; k <= i; k++)
                    {
                        Console.Write(value);
                        streamWriter.Write(value);
                    }
                    Console.Write(" ");
                    streamWriter.Write(" ");
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(value);
                        streamWriter.Write(value);
                    }
                    Console.WriteLine();
                    streamWriter.WriteLine();
                }
            }

            //字符菱形
            public void characterPrismatic(int line, string value, StreamWriter streamWriter)
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
                        streamWriter.Write(" ");
                    }
                    int put = 2 * i - 1;
                    while (put > 0)
                    {
                        Console.Write("{0}", value);
                        streamWriter.Write("{0}", value);
                        put--;
                    }
                    Console.WriteLine();
                    streamWriter.WriteLine();
                }

                for (int i = shortline+1; i <= line; i++)
                {
                    int put = i - shortline;
                    while (put > 0)
                    {
                        Console.Write(" ");
                        streamWriter.Write(" ");
                        put--;
                    }
                    int put2 = 2 * (line - i) + 1;
                    for (int j = 1; j <= put2; j++)
                    {
                        Console.Write("{0}",value);
                        streamWriter.Write("{0}", value);
                    }
                    Console.WriteLine();
                    streamWriter.WriteLine();
                }
            }

            //交替字符倒三角行
            public void alternateInvertedTriangle(int line, string value,StreamWriter streamWriter)
            {
                Console.WriteLine("交替字符倒三角形图象如下所示：");
                streamWriter.WriteLine("交替字符倒三角形图象如下所示：");
                for (int i = 1; i <= line; i++)
                {
                    for (int j = 1; j <= i-1; j++)
                    {
                        Console.Write(" ");
                        streamWriter.Write(" ");
                    }
                    int judge = 1;
                    while (judge <= 2 * (line - i + 1) - 1)
                    {
                        if (judge % 2 == 1)
                        {
                            Console.Write(value.Substring(0, 1));
                            streamWriter.Write(value.Substring(0, 1));
                        }                          
                        else
                            try
                            {
                                Console.Write(value.Substring(1, 1));
                                streamWriter.Write(value.Substring(1, 1));
                            }
                            catch(ArgumentOutOfRangeException e)
                            {
                                Console.WriteLine("请输入交替字符");
                                streamWriter.WriteLine("Exception caught: {0}", e);
                                break;
                            }
                        judge++;
                    }
                    Console.WriteLine();
                    streamWriter.WriteLine();
                }
            }
        }
        class FileController
        {
            /// <summary>
            /// 写文件
            ///<param name="Path">文件名称</param>
            /// <param name="Content">写入内容</param>
            /// </summary>
            public void CreateFile(string Path, string Content,StreamWriter streamWriter)
            { 
                //如果文件不存在创建文件
                if (!File.Exists(Path))
                {
                    FileStream filestream = File.Create(Path);
                    filestream.Close();
                    filestream.Dispose();
                }
                //写入内容
                streamWriter.WriteLine("文件创建时间"+Content);
               
                Console.WriteLine("文件创建成功");
            }

            /// <summary>
            /// 输出文件信息
            /// <param name="Path">文件名称</param>
            /// <param name="Content">写入内容</param>
            /// </summary>
            public void FileMessage(String Path, String Content, StreamWriter streamWriter)
            {
                Console.WriteLine("保存的文件信息如下：");
                Console.WriteLine("文件创建时间：" + DateTime.Now.ToString());
                Console.WriteLine("文件名称:" + Path);
                Console.WriteLine("文件保存路径：" + Environment.CurrentDirectory);

                streamWriter.WriteLine("查看文件信息：");
                streamWriter.WriteLine("保存的文件信息如下：");
                streamWriter.WriteLine("文件创建时间：" + DateTime.Now.ToString());
                streamWriter.WriteLine("文件名称:" + Path);
                streamWriter.WriteLine("文件保存路径：" + Environment.CurrentDirectory);
            }

            /// <summary>
            /// 将控制台输出信息保存进创建好的文本文件
            /// <param name="Path">文件名称</param>
            /// <param name="Content">写入内容</param>
            /// </summary>
            public void WriteFile(String Path,StreamWriter streamWriter,string AllPath)
            {
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Dispose();

                Console.WriteLine("写入txt文件成功");

                Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                Console.WriteLine("*******************************************");
                Console.WriteLine("1--查看文本文件     2--结束本应用");
                Console.WriteLine("*******************************************");
                int lastChoose = Convert.ToInt32(Console.ReadLine());
                //查看文本文件
                while (lastChoose == 1)
                {
                    StreamReader streamReader = new StreamReader(AllPath,false);
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line.ToString());
                    }
                    Console.ReadLine();

                    Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("1--查看文本文件     2--结束本应用");
                    Console.WriteLine("*******************************************");
                    lastChoose = Convert.ToInt32(Console.ReadLine());
                }
                //结束本应用
                while (lastChoose == 2)
                {
                    Console.WriteLine("程序将在三秒后退出");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                }

            }

        }
        static void Main(string[] args)
        {
           
                //选择是否要保存文件
                Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                Console.WriteLine("*******************************************");
                Console.WriteLine("1--打印控制台输出     2--不打印控制台输出");
                Console.WriteLine("*******************************************");
                int firstChoose = Convert.ToInt32(Console.ReadLine());

                //打印控制台输出
                while (firstChoose == 1)
                {
                    Console.WriteLine("请输入创建文件的名称");

                    //给变量赋值
                    string FirstPath = Console.ReadLine();
                    string Path = FirstPath + ".txt";
                    string Content = DateTime.Now.ToString();
                    string AllPath = Environment.CurrentDirectory + "\\" + Path;

                    //创建写入器
                    StreamWriter streamWriter = new StreamWriter(AllPath, false);
                    //创建对象
                    FileController fileController = new FileController();
                    //创建文件
                    fileController.CreateFile(Path, Content,streamWriter);


                while (true)
                {
                    //建立选择模式
                    //streamWriter.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                    Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("1--字符三角形     2--背靠背字符三角形");
                    Console.WriteLine("3--字符菱形       4--交替字符倒三角形");
                    Console.WriteLine("5--输出文件信息   6--保存控制台输出文件");
                    Console.WriteLine("*******************************************");
                    int choose1 = Convert.ToInt32(Console.ReadLine());

                    //字符三角形
                    while (choose1 == 1)
                    {
                        Console.WriteLine("请输入字符三角形的行数和值（每输入一个按Enter以继续)：");
                        streamWriter.WriteLine("请输入字符三角形的行数和值（每输入一个按Enter以继续)：");
                        try
                        {
                            int line = Convert.ToInt32(Console.ReadLine());
                            streamWriter.WriteLine("行数为"+line);
                            string value = Convert.ToString(Console.ReadLine());
                            streamWriter.WriteLine("字符为" + value);
                            Drawer drawer = new Drawer();
                            drawer.characterTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                            streamWriter.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //背靠背字符三角形
                    while (choose1 == 2)
                    {
                        try
                        {
                            Console.WriteLine("请输入背靠背字符三角形的行数和值（每输入一个按Enter以继续)：");
                            streamWriter.WriteLine("请输入背靠背字符三角形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            streamWriter.WriteLine("行数为" + line);
                            string value = Convert.ToString(Console.ReadLine());
                            streamWriter.WriteLine("字符为" + value);
                            Drawer drawer = new Drawer();
                            drawer.backCharacterTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                            streamWriter.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //字符菱形
                    while (choose1 == 3)
                    {
                        try
                        {
                            Console.WriteLine("请输入字符菱形的行数和值（每输入一个按Enter以继续)：");
                            streamWriter.WriteLine("请输入字符菱形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            streamWriter.WriteLine("行数为" + line);
                            string value = Convert.ToString(Console.ReadLine());
                            streamWriter.WriteLine("字符为" + value);
                            Drawer drawer = new Drawer();
                            drawer.characterPrismatic(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                            streamWriter.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //交替字符倒三角行
                    while (choose1 == 4)
                    {
                        try
                        {
                            Console.WriteLine("请输入交替字符倒三角形的行数和值（每输入一个按Enter以继续)：");
                            streamWriter.WriteLine("请输入交替字符倒三角形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            streamWriter.WriteLine("行数为" + line);
                            string value = Convert.ToString(Console.ReadLine());
                            streamWriter.WriteLine("字符为" + value);
                            Drawer drawer = new Drawer();
                            drawer.alternateInvertedTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                            streamWriter.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //输出文件信息
                    while (choose1 == 5)
                    {
                        //输出创建文件信息
                        fileController.FileMessage(Path, Content,streamWriter);
                        Console.ReadKey();
                        break;
                    }

                    //保存控制台输出信息进入文件
                    while (choose1 == 6)
                    {
                        fileController.WriteFile(Path, streamWriter,AllPath);
                        Console.ReadKey();
                        break;
                    }
                }
                   
                }

                //不打印控制台输出
                while (firstChoose == 2)
                {
                    //建立选择模式
                    Console.WriteLine("请选择您想要的函数模式（输入数字选择模式）:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("1--字符三角形     2--背靠背字符三角形");
                    Console.WriteLine("3--字符菱形       4--交替字符倒三角形");
                    Console.WriteLine("5--结束程序");
                    Console.WriteLine("*******************************************");
                    int choose2 = Convert.ToInt32(Console.ReadLine());

                    //给变量赋值
                    string FirstPath = Console.ReadLine();
                    string Path = FirstPath + ".txt";
                    string Content = DateTime.Now.ToString();
                    string AllPath = Environment.CurrentDirectory + "\\" + Path;

                    //创建写入器
                    StreamWriter streamWriter = new StreamWriter(AllPath, false);


                    //字符三角形
                    while (choose2 == 1)
                    {
                        Console.WriteLine("请输入字符三角形的行数和值（每输入一个按Enter以继续)：");
                        try
                        {
                            int line = Convert.ToInt32(Console.ReadLine());
                            string value = Convert.ToString(Console.ReadLine());
                            Drawer drawer = new Drawer();
                            drawer.characterTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                        }
                        Console.WriteLine("若运行结束，保存文件请按5");
                        Console.ReadKey();
                        break;
                    }

                    //背靠背字符三角形
                    while (choose2 == 2)
                    {
                        try
                        {
                            Console.WriteLine("请输入背靠背字符三角形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            string value = Convert.ToString(Console.ReadLine());
                            Drawer drawer = new Drawer();
                            drawer.backCharacterTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //字符菱形
                    while (choose2 == 3)
                    {
                        try
                        {
                            Console.WriteLine("请输入字符菱形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            string value = Convert.ToString(Console.ReadLine());
                            Drawer drawer = new Drawer();
                            drawer.characterPrismatic(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //交替字符倒三角行
                    while (choose2 == 4)
                    {
                        try
                        {
                            Console.WriteLine("请输入交替字符倒三角形的行数和值（每输入一个按Enter以继续)：");
                            int line = Convert.ToInt32(Console.ReadLine());
                            string value = Convert.ToString(Console.ReadLine());
                            Drawer drawer = new Drawer();
                            drawer.alternateInvertedTriangle(line, value,streamWriter);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                        }
                        Console.ReadKey();
                        break;
                    }

                    //结束程序
                    while (choose2 == 5)
                    {
                        Console.WriteLine("程序将在三秒后退出");
                        System.Threading.Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                }
              
            
        }  
    }
}

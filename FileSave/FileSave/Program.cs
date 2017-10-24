using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSave
{
    class Program
    {
        static void Main(string[] args)
        {
            fileRead(yangHuiSanJiao());
            Console.ReadKey();
        }

        public static String yangHuiSanJiao()
        {
            String path;
            String space = "  ";
            String[] spl;
            String str = "";
            int n = 0;
            int m;
            int i, j;
            Console.WriteLine("请输入杨辉三角的行数：");
            m = int.Parse(Console.ReadLine());
            spl = new String[2 * m + 1];
        myLabel:
            Console.WriteLine("请输入要创建的目录：");//盘符后加：/，目录分级用/，文件名自定义，无需加后缀
            path = Console.ReadLine() + ".txt";
            if (Directory.Exists(path.Remove(path.LastIndexOf('/'))))
            {
                Console.WriteLine("目录已存在，是否打开？T/F");
                while (true)
                {
                    string select = Console.ReadLine();
                    if (select == "T" || select == "t")
                        break;
                    if (select == "F" || select == "f")
                    {
                        goto myLabel;
                    }
                    Console.WriteLine("请输入T或F表示是或否：");
                }
            }
            else
            {
                Directory.CreateDirectory(path.Remove(path.LastIndexOf('/')));
                Console.WriteLine("已创建目录：{0}", path.Remove(path.LastIndexOf('/')));
            }

            if (File.Exists(path))
            {
                Console.WriteLine("文件已存在，是否打开？T/F");
                while (true)
                {
                    String select = Console.ReadLine();
                    if (select == "T" || select == "t")
                        break;
                    if (select == "F" || select == "f")
                    {
                        goto myLabel;
                    }

                    Console.WriteLine("请输入T或者F表示是或者否：");

                }
            }
            else
            {
                File.Create(path);
                Console.WriteLine("已创建文件");
            }
            FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            for (i = 0; i < m; i++)
            {
                space += " ";
            }

            Console.WriteLine(space + " 1");
            sw.WriteLine(space + " 1");
            for (i = 0; i < m - 1; i++)
            {
                space = space.Substring(1);
                for (j = 0; j < n; j++)
                {
                    String sss = (int.Parse(spl[j]) + int.Parse(spl[j + 1])).ToString();
                    str += sss.PadLeft(3, ' ');

                }
                if (str == "")
                    str = "1" + str + "  1";
                else
                    str = "1" + str + "  1";
                spl = str.Split(new string[] { " ", "  " }, StringSplitOptions.RemoveEmptyEntries);



                Console.WriteLine(space + str);
                sw.WriteLine(space + str);
                n++;
                str = "";

            }
            sw.Flush();
            sw.Close();
            fs.Close();

            return path;
        }


        public static void fileRead(String path)
        {
            String str;
            String[] sss;

            Console.WriteLine("文件成功写入，内容如下：");
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());


        copy:
            Console.WriteLine("请输入要复制的目录：");//盘符后加：/，目录分级用/，文件名自定义，无需加后缀
            str = Console.ReadLine() + ".txt";
            if (File.Exists(str))
            {
                Console.WriteLine("文件已存在，请重新输入");
                goto copy;
            }
            File.Copy(path, str);
            Console.WriteLine("文件复制成功，文件属性为：");
            Console.WriteLine(File.GetAttributes(str));
            Console.WriteLine("所在驱动器为：");
            Console.WriteLine(str.Substring(0, 2) + "\\");
            Console.WriteLine("此驱动器下目录列表为：");
            sss = Directory.GetFiles(str.Substring(0, 3));
            foreach (string srs in sss)
            {
                Console.WriteLine(srs);
            }
        }
    }
}

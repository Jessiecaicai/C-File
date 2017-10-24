using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace functionAndDraw
{
    class tool
    {
        //根据方法实现之后i是否为-1判断strnum是否为正整数
        //全局变量judge
        int judge;
        public int IsNumberic(string strnum)
        {
            if (strnum != null && Regex.IsMatch(strnum, @"^[0-9]*[1-9][0-9]*$"))
            {
                judge = int.Parse(strnum);
            }
            //else
            //judge = -1;
            judge = this.judge;
            return judge;
            
        }
        public void StratumOfFuction()
        {
            //无限循环
            while (true)
            {
                Console.Write("友情提示，过大的数字会导致结果不准确 \r\n please input the number :");
                //Console.Write("");
                string number = Console.ReadLine();
               
                //调用IsNumberic方法               
                IsNumberic(number);
                
                    if (judge!=-1)
                    {
                        int result = 1, count;
                        int intNumber = int.Parse(number);
                        for (count = 1; count <= intNumber; count++)
                        {
                            result = result * count;
                        }
                        Console.Write("it's stratum:");
                        Console.Write(result+"\r\n");
                    }
                    if (judge==-1)
                    {
                        //选择直接进行异常抛出；
                        Console.Write("错误的简要信息：We need Integer");
                    }
            }
                //catch (Exception e)
                //{
                    //Console.WriteLine("错误的简要信息：" + e.Message);
                //}
                Console.ReadLine();
        }
    }
}

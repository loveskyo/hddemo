using System;
using System.Collections.Generic;

namespace hddemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            playGame();
        }

        static int total = 0;
        static List<int> jihe = new List<int>();
        /// <summary>
        /// 游戏初始化
        /// </summary>
        private static void Init()
        {
            total = 0;
            jihe.Add(3);
            jihe.Add(5);
            jihe.Add(7);
        }

        /// <summary>
        /// 游戏入口
        /// </summary>
        private static void playGame()
        {
            while (true)
            {
                int rowIndex = 0;
                int num = 0;
                bool isPass = true;

                Console.WriteLine("一：您将从第几行拿取？请输入数字：");
                int.TryParse(Console.ReadLine(), out rowIndex);
                if (rowIndex <= 0 || rowIndex > 3 || jihe[rowIndex - 1] <= 0)
                {
                    isPass = false;
                    Console.WriteLine("error：输入错误请输入。回车继续！");
                    Console.ReadLine();
                }
                if (isPass)
                {
                    Console.WriteLine("二：您将从第 " + rowIndex + " 行拿取几根牙签？请输入数字：");
                    int.TryParse(Console.ReadLine(), out num);
                    if (num <= 0 || jihe[rowIndex - 1] - num < 0)
                    {
                        isPass = false;
                        Console.WriteLine("error：输入错误请输入不大于 " + jihe[rowIndex - 1] + " 的正整数。回车继续！");
                        Console.ReadLine();
                    }
                }
                if (isPass)
                {
                    string res = Extract(rowIndex, num);
                    if (res.Equals("end"))
                    {
                        break;
                    }
                    string _res = string.Empty;
                    jihe.ForEach((item) =>
                    {
                        _res = _res + "," + item;
                    });
                    Console.WriteLine("剩余：" + _res+ "回车继续！");
                    Console.ReadLine();

                }
            }
            if (total == 1)
                Console.WriteLine("游戏结束，您赢了！");
            else
                Console.WriteLine("游戏结束，您输了！");
            Console.ReadLine();
        }

        /// <summary>
        /// 牙签取出操作
        /// </summary>
        /// <param name="rowIndex">取出的行</param>
        /// <param name="num">取出的数</param>
        /// <returns></returns>
        private static string Extract(int rowIndex, int num)
        {
            string res = String.Empty;
            int temp = jihe[rowIndex - 1];
            total = 0;
            jihe[rowIndex - 1] = temp - num;

            jihe.ForEach((item) =>
            {
                total += item;
            });
            if (total > 1)
                res = "continue";
            else
                res = "end";

            return res;
        }
    }
}
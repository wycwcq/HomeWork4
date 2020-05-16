using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4_1
{
    class Program
    {
        public delegate void Hander(Clock clock);
        public class Clock
        {
            //属性
            public int nth, ntm, nts;
            public int sth, stm, sts;
            public Clock(int alh, int alm, int als)
            {
                sth = alh;
                stm = alm;
                sts = als;
                nth = DateTime.Now.Hour;
                ntm = DateTime.Now.Minute;
                nts = DateTime.Now.Second;
            }
            public Hander tick, alarm;
            public void StartClock()
            {
                int beginposition = 6;
                Console.WriteLine("Clock Start!");
                while (true)
                {
                    Console.SetCursorPosition(0, beginposition);
                    if (nth == sth && ntm == stm && nts == sts)
                    {
                        Alarm(this);
                        beginposition++;
                    }
                    else
                    {
                        Tick(this);
                    }
                    System.Threading.Thread.Sleep(1000);
                    nts++;
                    if(nts == 60)
                    {
                        ntm++;
                        nts = 0;
                    }
                    if(ntm == 60)
                    {
                        nth++;
                        ntm = 0;
                    }
                    if(nth==24)
                    {
                        nth = 0;
                    }
                }
            }
        }
        static void Alarm(Clock clock)
        {
            Console.WriteLine($"{clock.nth}:{clock.ntm}:{clock.nts}  Now_alarm");
        }
        static void Tick(Clock clock)
        {
            Console.WriteLine($"{clock.nth}:{clock.ntm}:{clock.nts}");
        }

        static void Main(string[] args)
        {
            Clock clock;
            Console.WriteLine("Alarm time:(hour)");
            string str1 = Console.ReadLine();
            Console.WriteLine("Alarm time:(minute)");
            string str2 = Console.ReadLine();
            Console.WriteLine("Alarm time:(second)");
            string str3 = Console.ReadLine();
            try
            {
                int h = Int32.Parse(str1);
                int m = Int32.Parse(str2);
                int s = Int32.Parse(str3);
                if(h < 0 || h >= 24 || m < 0 || m >= 60 || s < 0 || s >= 60)
                {
                    Console.WriteLine("时间输入有误!!!!!");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    clock = new Clock(h, m, s);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("输入错误!");
                Console.ReadKey();
                return;
            }
            clock.tick += Tick;
            clock.alarm += Alarm;
            clock.StartClock();
        }
    }
}

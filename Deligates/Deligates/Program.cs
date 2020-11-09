using System;

namespace Deligates
{
    //declare delegates
    public delegate void add(int x, int y);
    public delegate string name(string n);
    public delegate string favfood(string fname);
    class Program
    {
        public void addnum(int a, int b)
        {
            Console.WriteLine("sum of the numbers" + (a + b));

        }
        public void mul(int a, int b)
        {
            Console.WriteLine("product of the numbers" + (a * b));

        }
        public static string say(string name)
        {
            return "hello" + name;
        }

        public static void Main(string[] args)
        {
            //instaniating and calling
            Program p = new Program();
            add a = p.addnum;
            a += p.mul;
            a(100, 20);
            a(100, 10);
            name nw = new name(Program.say);
            string str = nw("rahul");
            Console.WriteLine(str);
            Console.ReadLine();
            //annannymos method
            favfood f = delegate (string fname)
            {
                return "favourite food is" + fname;
            };
            string s = f.Invoke("biriyani");
            Console.WriteLine(s);
            Console.ReadLine();
        

        }
    }

}
using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Child:Base
    {
        Child()
        {
            Console.WriteLine("cherry constructor"); 
        }
        public void cherry()
        {
            Console.WriteLine("cherry is red");
        }
        static void Main()
        {
            //Child obj = new Child(60);
            //obj.apple();
            //obj.mango();
            //obj.cherry();
            Base v;
            Child c1 = new Child();
            v = c1;
            v.lemon();
            v.apple();
            v.mango();
            Console.ReadLine();
        }
    }
}

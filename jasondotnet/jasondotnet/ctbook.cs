using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace jasondotnet
{
    class ctbook
    {
        public void serideseri()
        {
            Console.WriteLine("\nSerialization");
            laptop m = new laptop() { Name = "dell", price = 56000, rating = 9.6, yop = 2018, ramGB = 4 };
            string result = JsonConvert.SerializeObject(m);
            Console.WriteLine(result);


            Console.WriteLine("\nDeSerialization");

            laptop afterDeSerialize = JsonConvert.DeserializeObject<laptop>(result);
            Console.WriteLine("Name of The laptop is : " + afterDeSerialize.Name);
            Console.WriteLine("price of The laptop is : " + afterDeSerialize.price);
            Console.WriteLine("rating of The laptop is : " + afterDeSerialize.rating);
            Console.WriteLine("year of production of The laptop is : " + afterDeSerialize.yop);
            Console.WriteLine("ram of The laptop is : " + afterDeSerialize.ramGB);


        }
    }
       
}

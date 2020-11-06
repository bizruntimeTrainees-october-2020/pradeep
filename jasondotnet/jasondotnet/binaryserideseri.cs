using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace jasondotnet
{
    class binaryserideseri
    {
        public void binaryseri()
        {
            Console.WriteLine("\nSerialization");
            laptop m = new laptop() { Name = "dell", price = 56000, rating = 9.6, yop = 2018, ramGB = 4 };
            FileStream fileStream = new FileStream(@"E:\namew.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, m);
            
        }
        public void deyseri()
        {
            FileStream fileStream = new FileStream(@"E:\namew.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            laptop deserializedlaptop = (laptop)formatter.Deserialize(fileStream);
            Console.WriteLine($"Name:{ deserializedlaptop.Name}price:{ deserializedlaptop.price}rating:{ deserializedlaptop.rating}yop:{ deserializedlaptop.yop}price:{ deserializedlaptop.ramGB}");
        }

    }
}

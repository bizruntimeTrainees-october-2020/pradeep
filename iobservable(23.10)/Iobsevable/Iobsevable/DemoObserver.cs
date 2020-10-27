using System;
using System.Collections.Generic;
using System.Text;

namespace Iobsevable
{
    class DemoObserver : IObserver<int>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Observable is done sending all the data.");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Observable failed with error: {error.Message}");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"Observable emitted : {value}");
        }
    }
}

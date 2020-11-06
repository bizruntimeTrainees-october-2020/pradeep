using System;
using System.Reactive.Linq;

namespace reactdelay
{
    class Delay_Simple
    {
        static void Main()
        {
            var oneNumberEveryFiveSeconds = Observable.Interval(TimeSpan.FromSeconds(5));

            // Instant echo
            oneNumberEveryFiveSeconds.Subscribe(num =>
            {
                Console.WriteLine(num);
            });

            // One second delay
            oneNumberEveryFiveSeconds.Delay(TimeSpan.FromSeconds(1)).Subscribe(num =>
            {
                Console.WriteLine("...{0}...", num);
            });

            // Two second delay
            oneNumberEveryFiveSeconds.Delay(TimeSpan.FromSeconds(2)).Subscribe(num =>
            {
                Console.WriteLine("......{0}......", num);
            });

            Console.ReadKey();
        }
    }
}


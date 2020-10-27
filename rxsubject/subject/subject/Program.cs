using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using System.Threading;

namespace Example
{
    class Program
    {
        [Obsolete]
        public static void Main()
        {

            Subject<string> mySubject = new Subject<string>();
            NewsHeadlineFeed NewsFeed1 = new NewsHeadlineFeed("Headline News Feed #1");
            NewsFeed1.HeadlineFeed.Subscribe(mySubject);
            NewsHeadlineFeed NewsFeed2 = new NewsHeadlineFeed("Headline News Feed #2");
            NewsFeed2.HeadlineFeed.Subscribe(mySubject);


            Console.WriteLine("Subscribing to news headline feeds.\n\nPress ENTER to exit.\n");
            IDisposable allNewsSubscription = mySubject.Subscribe(x =>
            {
                Console.WriteLine("Subscription : All news subscription\n{0}\n", x);
            });
            IDisposable localNewsSubscription = mySubject.Where(x => x.Contains("in your area.")).Subscribe(x =>
            {
                Console.WriteLine("\n************************************\n" +
                                  "***[ Local news headline report ]***\n" +
                                  "************************************\n{0}\n\n", x);
            });

            Console.ReadLine();

            allNewsSubscription.Dispose();
            localNewsSubscription.Dispose();
        }
    }
    class NewsHeadlineFeed
    {
        private string feedName;                     // Feedname used to label the stream
        private IObservable<string> headlineFeed;    // The actual data stream
        private readonly Random rand = new Random(); // Used to stream random headlines.


        //*** A list of predefined news events to combine with a simple location string ***//
        static readonly string[] newsEvents = { "A tornado occurred ",
                                            "Weather watch for snow storm issued ",
                                            "A robbery occurred ",
                                            "We have a lottery winner ",
                                            "An earthquake occurred ",
                                            "Severe automobile accident "};

        //*** A list of predefined location strings to combine with a news event. ***//
        static readonly string[] newsLocations = { "in your area.",
                                               "in Dallas, Texas.",
                                               "somewhere in Iraq.",
                                               "Lincolnton, North Carolina",
                                               "Redmond, Washington"};

        public IObservable<string> HeadlineFeed
        {
            get { return headlineFeed; }
        }

        [Obsolete]
        public NewsHeadlineFeed(string name)
        {
            feedName = name;

            headlineFeed = Observable.Generate(RandNewsEvent(),
                                               evt => true,
                                               evt => RandNewsEvent(),
                                               evt => { Thread.Sleep(rand.Next(5000)); return evt; },
                                               Scheduler.ThreadPool);
        }

        private string RandNewsEvent()
        {
            return "Feedname     : " + feedName + "\nHeadline     : " + newsEvents[rand.Next(newsEvents.Length)] +
                   newsLocations[rand.Next(newsLocations.Length)];
        }
    }
}
using System;

namespace Iobsevable
{
    class Program
    {
        private static void Main(string[] args)
        {
            var observableInstance = new DemoObservable();
            var observerInstance = new DemoObserver();
            var subscriptionHandle = observableInstance.Subscribe(observerInstance);
        }
    }
}

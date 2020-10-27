using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Disposables;

namespace Iobsevable
{
    class DemoObservable : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnNext(4);
            observer.OnNext(5);
            observer.OnCompleted();
            return Disposable.Empty;
        }
    }
}

using System;
using System.Collections.Generic;

class Observable<T>: IObservable<T>
{
    private List<IObserver<T>> observers = new List<IObserver<T>>();
    public IDisposable Subscribe(IObserver<T> observer){
        observers.Add(observer);
        return new Subscription<T>(observers, observer);
    }

    public void Publish(T data){
        foreach(var observer in observers){
            observer.OnNext(data);
        }
    }    
}
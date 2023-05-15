using System;
using System.Collections.Generic;

class Subscription<T>: IDisposable{
    private List<IObserver<T>> observers;
    private IObserver<T> observer;

    public Subscription(List<IObserver<T>> observers, IObserver<T> observer){
        this.observers = observers;
        this.observer = observer;
    }

    public void Dispose(){
        if(observer != null && observers.Contains(observer)){
            observers.Remove(observer);
        }
    }
}
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

class Observer<T>: IObserver<T>{
    private IDisposable unsubscriber;
    private string name;

    public Observer(string name){
        this.name = name;
    }

    public void Subscribe(IObservable<T> provider){
        unsubscriber = provider.Subscribe(this);
    }

    public void OnNext(T data){
        Console.WriteLine($"{name} received {data}");
    }

    public void OnError(Exception error){
        Console.WriteLine($"{name} received error {error.Message}");
    }

    public void OnCompleted(){
        Console.WriteLine($"{name} received completed notification");
    }

    public void Unsubscribe(){
        unsubscriber.Dispose();
    }
}

class Program{
    static void Main(string[] args){
        Observable<string> observable = new Observable<string>();

        Observer<string> observer1 = new Observer<string>("Observer-1");
        Observer<string> observer2 = new Observer<string>("Observer-2");

        observer1.Subscribe(observable);
        observer2.Subscribe(observable);

        observable.Publish("First message");
        observable.Publish("Second message");

        observer1.Unsubscribe();
        observable.Publish("Third message");
    }
}
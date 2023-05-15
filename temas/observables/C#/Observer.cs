using System;

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
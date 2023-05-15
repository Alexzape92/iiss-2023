using System;

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
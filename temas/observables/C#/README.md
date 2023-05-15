# Ejemplo de Observables en C#
## Compilación y ejecución
Para compilar el programa, ejecutamos:

    mcs *.cs -out:Program.exe
Y para ejecutarlo:

    mono Program.exe

## Ejemplo
En este ejemplo, se crea una clase observable genérica, que recibirá un tipo de dato genérico, y que tendrá un método para añadir observadores, y otro para notificar a los observadores de que se ha producido un cambio en el objeto observable.

[Observable.cs](Observable.cs)
```csharp
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
```

También se crea una clase que implementa la interfaz `IObserver<T>`, que recibirá un tipo de dato genérico, y que tendrá un método para recibir notificaciones de un objeto observable.

[Observer.cs](Observer.cs)
```csharp
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
```

Por último, se crea una clase que implementa la interfaz `IDisposable`, que recibirá un tipo de dato genérico, y que tendrá un método para eliminar un observador de la lista de observadores de un objeto observable.

[Subscription.cs](Subscription.cs)
```csharp
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
```

A continuación, se muestra el comportamiento del programa principal:

[Program.cs](Program.cs)
```csharp
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
```

Vemos que se crean dos observadores, y se suscriben al objeto observable. A continuación, el objeto observable publica dos mensajes, que son recibidos por los dos observadores. Por último, se elimina el primer observador, y se publica un tercer mensaje, que solo es recibido por el segundo observador.

En efecto, la salida es la siguiente:

    Observer-1 received First message
    Observer-2 received First message
    Observer-1 received Second message
    Observer-2 received Second message
    Observer-2 received Third message
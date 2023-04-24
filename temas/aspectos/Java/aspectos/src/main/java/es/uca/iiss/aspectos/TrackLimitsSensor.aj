package es.uca.iiss.aspectos;

public aspect TrackLimitsSensor{
    pointcut turnMade(Turn turn, float speed, F1Car car): 
        call(boolean F1Car.makeTurn(Turn, float)) && args(turn, speed) && target(car);
    
    after(Turn turn, float speed, F1Car car): turnMade(turn, speed, car){
        if (speed > turn.getMaxSpeed()){
            Fia.penalize(car.getNumber(), 5);
        }
    }
}
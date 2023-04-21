package es.uca.iiss.aspectos;

import java.util.*;

public class Fia {
    private static Map<Integer, Integer> penalties = new HashMap<Integer, Integer>();

    public static void penalize(Integer car, int seconds) {
        if (penalties.containsKey(car)) {
            penalties.put(car, penalties.get(car) + seconds);
        } else {
            penalties.put(car, seconds);
        }
    }

    public static int getPenalty(Integer car) {
        if (penalties.containsKey(car)) {
            return penalties.get(car);
        } else {
            return 0;
        }
    }
}

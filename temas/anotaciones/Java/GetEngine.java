public class GetEngine {
    public Engine getEngine(Object obj) {
        Class<?> c = obj.getClass();
        EngineType engineType = c.getAnnotation(EngineType.class);
        Class<?> engineClass = engineType.value();
        Engine engine = null;
        try {
            engine = (Engine) engineClass.getDeclaredConstructor().newInstance();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return engine;
    }
}

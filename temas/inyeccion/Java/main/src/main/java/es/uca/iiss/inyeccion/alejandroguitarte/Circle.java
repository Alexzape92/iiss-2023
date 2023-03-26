package es.uca.iiss.inyeccion.alejandroguitarte;

public class Circle implements IShape {
    private float radius;

    public Circle(float radius) {
        this.radius = radius;
    }

    public void draw() {
        System.out.println("Esto es un circulo de area " + getArea() + " y perimetro " + getPerimeter() + ".");
    }

    public float getArea() {
        return (float) (Math.PI * radius * radius);
    }

    public float getPerimeter() {
        return (float) (2 * Math.PI * radius);
    }
}

package es.uca.iiss.inyeccion.alejandroguitarte;

import org.springframework.context.ApplicationContext;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class Main 
{
    public static void main( String[] args )
    {
        IShape shape;

        ApplicationContext context = new ClassPathXmlApplicationContext("Beans.xml");
        shape = (IShape)context.getBean("ShapeType", 2f);
        ((ConfigurableApplicationContext)context).close();

        shape.draw();
    }
}

# Ejemplo de Inyección
## Configuración
En este ejemplo, usaremos Java en conjunto a Maven, para crear el proyecto necesario. En mi caso he usado Visual Studio Code para crear, compilar y depurar el proyecto Maven, aunque se puede usar cualquier otro.

Lo primero es configurar nuestro `pom.xml`:

[pom.xml](pom.xml)
```xml
<?xml version="1.0" encoding="UTF-8"?>

<project xmlns="http://maven.apache.org/POM/4.0.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd">
  <modelVersion>4.0.0</modelVersion>

  <groupId>es.uca.iiss.inyeccion.alejandroguitarte</groupId>
  <artifactId>main</artifactId>
  <version>1.0</version>

  <name>main</name>
  <!-- FIXME change it to the project's website -->
  <url>http://www.example.com</url>

  <properties>
    <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    <maven.compiler.source>17</maven.compiler.source>
    <maven.compiler.target>17</maven.compiler.target>
  </properties>

  <dependencies>
    <dependency>
      <groupId>junit</groupId>
      <artifactId>junit</artifactId>
      <version>4.11</version>
      <scope>test</scope>
    </dependency>
    <dependency>
      <groupId>org.springframework</groupId>
      <artifactId>spring-context</artifactId>
      <version>6.0.6</version>
    </dependency>
  </dependencies>

  <build>
    <pluginManagement><!-- lock down plugins versions to avoid using Maven defaults (may be moved to parent pom) -->
      <plugins>
        <!-- clean lifecycle, see https://maven.apache.org/ref/current/maven-core/lifecycles.html#clean_Lifecycle -->
        <plugin>
          <artifactId>maven-clean-plugin</artifactId>
          <version>3.1.0</version>
        </plugin>
        <!-- default lifecycle, jar packaging: see https://maven.apache.org/ref/current/maven-core/default-bindings.html#Plugin_bindings_for_jar_packaging -->
        <plugin>
          <artifactId>maven-resources-plugin</artifactId>
          <version>3.0.2</version>
        </plugin>
        <plugin>
          <artifactId>maven-compiler-plugin</artifactId>
          <version>3.8.0</version>
        </plugin>
        <plugin>
          <artifactId>maven-surefire-plugin</artifactId>
          <version>2.22.1</version>
        </plugin>
        <plugin>
          <artifactId>maven-jar-plugin</artifactId>
          <version>3.0.2</version>
        </plugin>
        <plugin>
          <artifactId>maven-install-plugin</artifactId>
          <version>2.5.2</version>
        </plugin>
        <plugin>
          <artifactId>maven-deploy-plugin</artifactId>
          <version>2.8.2</version>
        </plugin>
        <!-- site lifecycle, see https://maven.apache.org/ref/current/maven-core/lifecycles.html#site_Lifecycle -->
        <plugin>
          <artifactId>maven-site-plugin</artifactId>
          <version>3.7.1</version>
        </plugin>
        <plugin>
          <artifactId>maven-project-info-reports-plugin</artifactId>
          <version>3.0.0</version>
        </plugin>
      </plugins>
    </pluginManagement>
  </build>
</project>
```

Aquí lo que se debe destacar es la versión de java a utilizar en la compilación (>=17), especificado en `<maven.compile.target>` y `<maven.compile.source>`, y que hay que agregar la dependenicia de `spring-context`.

A continuación, creamos nuestro código fuente, que es muy simple en nuestro caso.

## Ejemplo
[Main.java](src/main/java/es/uca/iiss/inyeccion/alejandroguitarte/Main.java)
```java
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
```
Vemos como tenemos una variable de tipo `Ishape` que es inicializada por Spring, obteniendo la Bean `ShapeType`, con parámetro 2. Esta bean va a instanciar un objeto de la clase `Circle` con radio 2, sin necesidad de incluir el `new Circle(2)` en nuestro código, lo cual generaría acoplamientos innecesarios. Veamos como se define la bean:

[Beans.xml](src/main/java/Beans.xml)
```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE beans PUBLIC "-//SPRING//DTD BEAN//EN"
"http://www.springframework.org/dtd/spring-beans.dtd">

<beans>
    <bean id="ShapeType" class="es.uca.iiss.inyeccion.alejandroguitarte.Circle" scope="prototype"/>
</beans>
```
Como podemos ver, se está definiendo la bean con id `ShapeType` que instancia la clase `Circle`. Se declara con la scope `prototype` para que se le puedan pasar parámetros al obtener la bean.

Para entender la salida, veremos que hacen el resto de clases:

[IShape.java](src/main/java/es/uca/iiss/inyeccion/alejandroguitarte/IShape.java)
```java
package es.uca.iiss.inyeccion.alejandroguitarte;

public interface IShape {
    public void draw();
    public float getArea();
    public float getPerimeter();
}
```

[Circle.java](src/main/java/es/uca/iiss/inyeccion/alejandroguitarte/Circle.java)
```java
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
```

Simplemente, se llamará al método `draw()`, el cual imprimirá por pantalla que es un círculo, junto con su área y perímetro. En efecto, la salida es:

    Esto es un circulo de area 12.566371 y perimetro 12.566371.

## Conclusiones
La inyección de dependencias es un mecanismo muy útil para reducir acoplamientos. De esta manera, si en un futuro se pretendiera que el programa imprimiera los datos de un cuadrado en lugar de un círculo, se podría crear una clase cuadrado que implemente `IShape`, y cambiar la bean `ShapeType` a un objeto cuadrado, y el programa haría lo deseado. De esta manera, estamos cumpliendo el principio `Open-Closed`, ya que tan sólo agregando código, sin modificar el existente, conseguimos modificar la funcionalidad de la aplicación.
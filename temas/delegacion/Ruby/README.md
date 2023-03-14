# Ejemplo de Encapsulación en Ruby
## Instrucciones de Ejecución
Para ejecutar el código, simplemente ejecutamos en la línea de comandos:

    ruby modules.rb
## Ejemplo
En este caso, vamos a implementar una relación de delegación utilizando los módulos de ruby. Estos son un mecanismo muy útil de reutilización de código, de manera que conseguimos incorporar funcionalidades en una clase sin recurrir a la herencia de comportamiento. Veamos el código fuente:

```ruby
require 'digest'

module Sha256
    def encriptar(mensaje)
        Digest::SHA2.hexdigest(mensaje)
    end

    def comprobar(hash, msg)
        newhash = Digest::SHA2.hexdigest(msg)
        hash == newhash
    end
end

class Cliente
    include Sha256
    def registrar(contraseña)
        @passwd = encriptar(contraseña)
        puts @passwd
    end

    def login(pass)
        if comprobar(@passwd, pass)
            puts "Has iniciado sesion correctamente"
        else
            puts "Contraseña incorrecta"
        end
    end
end

cliente = Cliente.new
cliente.registrar("Alejandro")
cliente.login("Estoestamal")
cliente.login("Alejandro")
```
En este caso, tenemos un módulo llamado Sha256 que contiene métodos para encriptar un mensaje, y comprobar si un mensaje corresponde a un hash SHA256. Tenemos una sencilla clase `Cliente` que incluye este módulo, y lo utiliza para registrarse con una contraseña y logearse con otra. Esto no es como una herencia en Java, ya que la clase cliente no es de tipo `Sha256`, simplemente incorpora su comportamiento. De esta manera, agrupamos estas funciones en un módulo que más adelante podremos utilizar en otras clases que puedan necesitarlo, sin necesidad de duplicar código. La salida de este programa es la siguiente:

    30cc1cb006f560be31de08160f80efe06635bd3efb8cb8745cf74d6ca8f6d921
    Contraseña incorrecta
    Has iniciado sesion correctamente

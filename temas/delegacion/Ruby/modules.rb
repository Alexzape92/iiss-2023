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
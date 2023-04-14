import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { getRepository, Repository } from 'typeorm';
import { Jugador } from './jugador.entity';


@Injectable()
export class JugadorService {
    constructor(
        @InjectRepository(Jugador)
        private jugadorRepository: Repository<Jugador>,
    ) { }

    helloJugador(): string{
        return "Hola Jugador!";
    }
    showUsuario(usuario: string): string{
        return "Hola "+usuario;
    }
    buscarUsuario(usuario: string): Promise<Jugador>{
        const respuesta = getRepository(Jugador)
            .createQueryBuilder("jugador")
            .select()
            .where("jugador.id_usuario = :usuario ", { usuario: usuario})
            .getOneOrFail();
        return respuesta;
    }
    registroJugador(usuario: string,
        nombre: string,
        ciudad: string,
        mail: string,
        contrasena: string,
        fechaNaci: Date,
        nacionalidad: string) {
        const answer = getRepository(Jugador)
            .createQueryBuilder()
            .insert()
            .into(Jugador)
            .values([
                {id_usuario: usuario, 
                nombre: nombre,
                ciudad: ciudad,
                pais: nacionalidad,
                email: mail,
                contrasena: contrasena,
                fecha_nacimiento: fechaNaci}
            ])
            .execute();
    }
    inicioSesion(usuario: string, contrasena: string): Promise<Jugador>{
        const respuesta = getRepository(Jugador)
            .createQueryBuilder("jugador")
            .select('jugador.id_usuario')
            .where("jugador.id_usuario = :usuario AND jugador.contrasena = :contrasena", { usuario: usuario, contrasena: contrasena})
            .getOneOrFail();
        return respuesta;
    }
}
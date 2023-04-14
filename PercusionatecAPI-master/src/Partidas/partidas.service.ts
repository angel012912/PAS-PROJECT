import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { getRepository, Repository } from 'typeorm';
import { Partidas } from './partidas.entity';
import { Jugador } from '../Jugador/jugador.entity';


@Injectable()
export class PartidasService {
    constructor(
        @InjectRepository(Partidas)
        private partidasRepository: Repository<Partidas>,
    ) { }

    helloPartidas(): string{
        return "Hola, esta es la ruta para partidas";
    }
    buscarIdPartida(usuario: Jugador, inicio: Date): Promise<Partidas>{
        const respuesta = getRepository(Partidas)
            .createQueryBuilder("partidas")
            .select()
            .where("Tiempo_Conecta = :inicio AND jugadorIdUsuario = :usuario", { usuario: usuario, inicio: inicio})
            .getOneOrFail();
        return respuesta;
    }
    ingresarConectaPartida(usuario: Jugador, inicio: Date){
        const answer = getRepository(Partidas)
        .createQueryBuilder()
        .insert()
        .into(Partidas)
        .values([
            {
            Tiempo_Conecta: inicio, 
            jugador: usuario
            }
        ])
        .execute();
    }
    actualizarTermino(id_partida: number,termino: Date){
        const answer=getRepository(Partidas)
        .createQueryBuilder()
        .update(Partidas)
        .set({ Tiempo_Desconecta: termino})
        .where("Id_partida = :id", { id: id_partida })
        .execute();
    }
}
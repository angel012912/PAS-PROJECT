import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Niveles } from 'src/Niveles/niveles.entity';
import { getRepository, Repository } from 'typeorm';
import { PartidaNivel } from './partida_nivel.entity';
import {Partidas } from '../Partidas/partidas.entity';



@Injectable()
export class PartidaNivelService {
    constructor(
        @InjectRepository(PartidaNivel)
        private partida_nivelRepository: Repository<PartidaNivel>,
    ) { }

    helloPartidaNivel(): string{
        return "Bienvenido a partida nivel!";
    }
    ingresaPartidaNivel(partida: Partidas, nivel: Niveles, puntaje: number){
        const answer = getRepository(PartidaNivel)
        .createQueryBuilder()
        .insert()
        .into(PartidaNivel)
        .values([
            {
            puntaje: puntaje, 
            niveles: nivel,
            partidas: partida
            }
        ])
        .execute();
    }
    verificarPartidaNivel(partida: Partidas, nivel: Niveles){
        const respuesta = getRepository(PartidaNivel)
            .createQueryBuilder("partida_nivel")
            .select()
            .where("partida_nivel.niveles = :nivel AND partida_nivel.partidas = :partida ", { nivel: nivel, partida: partida})
            .getOneOrFail();
        return respuesta;
    }
    actualizarScore(id: number, puntaje: number){
        const answer=getRepository(PartidaNivel)
        .createQueryBuilder()
        .update(PartidaNivel)
        .set({puntaje: puntaje})
        .where("id_partida_nivel = :id", { id: id })
        .execute();
    }
}
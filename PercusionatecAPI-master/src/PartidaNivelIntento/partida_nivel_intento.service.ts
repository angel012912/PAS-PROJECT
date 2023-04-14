import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { getRepository, Repository } from 'typeorm';
import { PartidaNivelIntento } from './partida_nivel_intento.entity';
import { PartidaNivel } from 'src/Partida_Nivel/partida_nivel.entity';

@Injectable()
export class PartidaNivelIntentoService {
    constructor(
        @InjectRepository(PartidaNivelIntento)
        private partida_nivel_intentoRepository: Repository<PartidaNivelIntento>,
    ) { }

    helloPartidaNivelIntento(): string{
        return "Bienvenido a partida nivel intento";
    }
    insertarIntento(errores: number, Inicio: Date, Final: Date, partida_nivel: PartidaNivel){
        const answer = getRepository(PartidaNivelIntento)
        .createQueryBuilder()
        .insert()
        .into(PartidaNivelIntento)
        .values([
            {
            errores: errores, 
            Inicio: Inicio,
            Final: Final,
            partida_nivel: partida_nivel
            }
        ])
        .execute();
    }
}
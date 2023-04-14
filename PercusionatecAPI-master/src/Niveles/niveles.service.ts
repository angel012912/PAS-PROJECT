import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { getRepository, Repository } from 'typeorm';
import { Niveles } from './niveles.entity';


@Injectable()
export class NivelesService {
    constructor(
        @InjectRepository(Niveles)
        private nivelRepository: Repository<Niveles>,
    ) { }

    helloNiveles(): string{
        return "Hola, esta es la ruta para niveles";
    }
}
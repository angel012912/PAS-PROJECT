import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { PartidaNivelIntento } from './partida_nivel_intento.entity';
import { PartidaNivelIntentoService } from './partida_nivel_intento.service';
import { PartidaNivelIntentoController } from './partida_nivel_intento.controller';

@Module({
    imports: [TypeOrmModule.forFeature([PartidaNivelIntento])],
    providers: [PartidaNivelIntentoService],
    controllers: [PartidaNivelIntentoController],
})

export class PartidaNivelIntentoModule { }
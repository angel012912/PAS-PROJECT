import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { PartidaNivel } from './partida_nivel.entity';
import { PartidaNivelService } from './partida_nivel.service';
import { PartidaNivelController } from './partida_nivel.controller';

@Module({
    imports: [TypeOrmModule.forFeature([PartidaNivel])],
    providers: [PartidaNivelService],
    controllers: [PartidaNivelController],
})

export class PartidaNivelModule { }
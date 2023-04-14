import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Partidas } from './partidas.entity';
import { PartidasService } from './partidas.service';
import { PartidasController } from './partidas.controller';

@Module({
    imports: [TypeOrmModule.forFeature([Partidas])],
    providers: [PartidasService],
    controllers: [PartidasController],
})

export class PartidasModule { }
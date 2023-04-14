import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Jugador } from './jugador.entity';
import { JugadorService } from './jugador.service';
import { JugadorController } from './jugador.controller';

@Module({
    imports: [TypeOrmModule.forFeature([Jugador])],
    providers: [JugadorService],
    controllers: [JugadorController],
})

export class JugadorModule { }
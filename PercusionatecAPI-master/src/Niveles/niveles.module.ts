import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Niveles } from './niveles.entity';
import { NivelesService } from './niveles.service';
import { NivelesController } from './niveles.controller';

@Module({
    imports: [TypeOrmModule.forFeature([Niveles])],
    providers: [NivelesService],
    controllers: [NivelesController],
})

export class NivelesModule { }
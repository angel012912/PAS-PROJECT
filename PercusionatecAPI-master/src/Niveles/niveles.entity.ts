import { Entity, Column, PrimaryGeneratedColumn, OneToMany} from 'typeorm';
import { PartidaNivel } from '../Partida_Nivel/partida_nivel.entity';


@Entity()
export class Niveles{
    @PrimaryGeneratedColumn()
    Id_nivel: number;
    @Column()
    instrumentos: string;
    @Column()
    no_teclas: number;
    @Column()
    tiempoMinimo: number;
    @OneToMany(()=>PartidaNivel, (partida_nivel)=>partida_nivel.niveles)
    partida_nivel: PartidaNivel[];
}


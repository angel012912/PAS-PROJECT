import { Entity, Column, JoinColumn, OneToOne, PrimaryGeneratedColumn, ManyToOne, OneToMany } from 'typeorm';
import { Partidas } from '../Partidas/partidas.entity';
import { Niveles } from '../Niveles/niveles.entity';
import { PartidaNivelIntento } from 'src/PartidaNivelIntento/partida_nivel_intento.entity';


@Entity()
export class PartidaNivel{
    @PrimaryGeneratedColumn()
    id_partida_nivel:number;
    @Column()
    puntaje: number;
    @OneToMany(()=> PartidaNivelIntento, (partida_intento) => partida_intento.partida_nivel)
    partida_intentos: PartidaNivelIntento[];
    @ManyToOne(() => Niveles, (nivel) => nivel.partida_nivel)
    niveles: Niveles;
    @ManyToOne(() => Partidas, (partida) => partida.partida_nivel)
    partidas: Partidas;
    
}


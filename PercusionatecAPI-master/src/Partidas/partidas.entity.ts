import { Jugador } from 'src/Jugador/jugador.entity';
import { PartidaNivel } from 'src/Partida_Nivel/partida_nivel.entity';
import { Entity, Column, JoinColumn, OneToOne,OneToMany, PrimaryGeneratedColumn, ManyToOne } from 'typeorm';


@Entity()
export class Partidas{
    @PrimaryGeneratedColumn()
    Id_partida: number;
    @Column('datetime')
    Tiempo_Conecta: Date;
    @Column({type: 'datetime', default: ()=> '(CURRENT_DATE)'})
    Tiempo_Desconecta: Date;
    @OneToMany(()=>PartidaNivel, (partida_nivel)=>partida_nivel.partidas)
    partida_nivel: PartidaNivel[];
    @ManyToOne(() => Jugador, (jugador) => jugador.partidas)
    jugador: Jugador;
}


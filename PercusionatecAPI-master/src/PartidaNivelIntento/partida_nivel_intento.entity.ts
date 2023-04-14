import { Entity, Column, JoinColumn, OneToOne, PrimaryGeneratedColumn, ManyToOne, OneToMany } from 'typeorm';
import { PartidaNivel } from '../Partida_Nivel/partida_nivel.entity';


@Entity()
export class PartidaNivelIntento{
    @PrimaryGeneratedColumn()
    idIntento:number;
    @Column()
    errores: number;
    @Column('datetime')
    Inicio: Date;
    @Column('datetime')
    Final: Date;
    @ManyToOne(()=>PartidaNivel, (partida_nivel) => partida_nivel.partida_intentos)
    partida_nivel : PartidaNivel;
}


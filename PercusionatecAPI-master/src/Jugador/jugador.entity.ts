import { Entity, Column, PrimaryGeneratedColumn, OneToMany} from 'typeorm';
import { Partidas } from '../Partidas/partidas.entity';


@Entity()
export class Jugador{
    @PrimaryGeneratedColumn('uuid')
    id_usuario:string;
    @Column()
    nombre: string;
    @Column()
    ciudad: string;
    @Column()
    pais: string;
    @Column()
    email: string;
    @Column()
    contrasena: string;
    @Column('date')
    fecha_nacimiento: Date;
    @OneToMany(()=>Partidas, (partida)=>partida.jugador)
    partidas: Partidas[];
}


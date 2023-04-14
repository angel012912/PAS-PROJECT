import { Body, Controller, Get, Param, Post, UnsupportedMediaTypeException } from "@nestjs/common";
import { PartidasService } from './partidas.service';

@Controller('partidas')
export class PartidasController {
    constructor(private readonly Partidasservice: PartidasService) { }

    @Get()
    sayHelloPartidas(): string {
        var answer = this.Partidasservice.helloPartidas();
        return answer;
    }

    @Get(':usuario/:inicio')
    async sayBuscarPartida(@Param('usuario') usuario, @Param('inicio') inicio){
        var res = this.Partidasservice.buscarIdPartida(usuario, inicio);
        return (await res).Id_partida;
    }
    @Post()
    async sayIngresarConectaPartida(@Body() body){
        const res = this.Partidasservice.ingresarConectaPartida(body.usuarioConecta, body.tiempoConecta);
        return "Se registro cuando se conecta a la partida";
    }
    @Post(':id_partida')
    sayActualizarTermino(@Param('id_partida') partida, @Body() body){
        const res = this.Partidasservice.actualizarTermino(partida, body.horaTermino);
        return "Se actualizo la hora de termino";
    }
}
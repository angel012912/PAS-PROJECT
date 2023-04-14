import { Body, Controller, Get, Param, Post } from "@nestjs/common";
import { identity } from "rxjs";
import { PartidaNivel } from "./partida_nivel.entity";
import { PartidaNivelService } from './partida_nivel.service';

@Controller('partida_nivel')
export class PartidaNivelController {
    constructor(private readonly PartidaNivelservice: PartidaNivelService) { }

    @Get()
    sayHelloPartidaNivel(): string {
        var answer = this.PartidaNivelservice.helloPartidaNivel();
        return answer;
    }    
    @Get(':partida/:nivel')
    async sayVerificaPartidaNivel(@Param('partida') partida, @Param('nivel') nivel){
        var answer = this.PartidaNivelservice.verificarPartidaNivel(partida, nivel);
        return (await answer).id_partida_nivel;
    }
    @Post()
    sayIngresaPartidaNivel(@Body() body): string{
        var answer = this.PartidaNivelservice.ingresaPartidaNivel(body.partida, body.nivel, body.puntaje);
        return "Se ingresó";
    }
    @Post(':id')
    sayActualizarScore(@Param('id') id, @Body() body){
        var answer = this.PartidaNivelservice.actualizarScore(id, body.score);
        return "Se actualizó";
    }
}
import { Body, Controller, Get, Param, Post } from "@nestjs/common";
import { PartidaNivelIntentoService } from './partida_nivel_intento.service';

@Controller('partida_nivel_intento')
export class PartidaNivelIntentoController {
    constructor(private readonly PartidaNivelIntentoservice: PartidaNivelIntentoService) { }

    @Get()
    sayHelloPartidaNivelIntento(): string {
        var answer = this.PartidaNivelIntentoservice.helloPartidaNivelIntento();
        return answer;
    } 
    @Post()
    sayInsertarIntento(@Body() body): String{
        console.log("Ingresa a la funcion"); 
        var answer = this.PartidaNivelIntentoservice.insertarIntento(body.errores,body.inicio,body.final,body.idPartNivel);
        return "Se ingreso el intento";
    }
}
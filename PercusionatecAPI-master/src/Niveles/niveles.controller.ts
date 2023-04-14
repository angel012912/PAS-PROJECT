import { Body, Controller, Get, Param, Post } from "@nestjs/common";
import { NivelesService } from './niveles.service';

@Controller('niveles')
export class NivelesController {
    constructor(private readonly Nivelesservice: NivelesService) { }

    @Get()
    sayHelloNiveles(): string {
        var answer = this.Nivelesservice.helloNiveles();
        return answer;
    }    
}
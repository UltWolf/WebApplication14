import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {TranslatePipe} from "../translation";
import {TranslateService} from "./translate.service";





@NgModule({

    imports: [

        CommonModule,

        CommonModule,

        FormsModule,
    ],

    declarations: [TranslatePipe],
    exports:[TranslatePipe],
    providers: [TranslateService],

})

export class TranslationtModule { }
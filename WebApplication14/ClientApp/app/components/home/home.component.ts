import {Component, OnInit} from '@angular/core';
import {TranslateService} from "../translation/translate.service";
import {AuthenticationService} from "../_services/auth.services";

@Component({
    selector: 'home',
    providers:[AuthenticationService,TranslateService],
    templateUrl: './home.component.html'
})
export class HomeComponent {

    constructor(private authService: AuthenticationService,private _translate: TranslateService) {
    }

}

import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';

import { AuthenticationService } from '../_services/auth.services';
import {TranslateService} from "../translation/translate.service";
import { EventBrokerService } from '../_services/event.services';
import any = jasmine.any;
import {NavMenuComponent} from "../navmenu/navmenu.component";

@Component({
    selector: 'app',
    providers: [ EventBrokerService],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],

})
export class AppComponent  {
    public supportedLanguages: any[];
    public translatedText: string;
    public isAuth: boolean = false;
    @Input()
    AuthEmitIn:boolean;
    @Output() onChanged = new EventEmitter<boolean>()


    constructor(private authService: AuthenticationService, private _translate: TranslateService, private _eventBroker: EventBrokerService) {
        this.isAuth = this.authService.isLogg();
    }

    ngOnInit():void {
        this.supportedLanguages = [
            { display: 'English', value: 'en' },
            { display: 'Русский', value: 'ru' },
        ];
    }

    isCurrentLang(lang: string) {
        return lang === this._translate.GetLanguage();
    }
    GetAuth() {
        this.isAuth = this.authService.isLogg();
        this.onChanged.emit(this.isAuth);
    }
    selectLang(lang: string) {
        this._eventBroker.emit<string>("my-event", lang);
        console.log("EmitStart");
        this._translate.SetLanguage(lang);
    }


}

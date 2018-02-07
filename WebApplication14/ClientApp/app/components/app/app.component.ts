import {Component, EventEmitter, Input, OnChanges, OnInit} from '@angular/core';
import { AuthenticationService } from '../_services/auth.services';
import {TranslateService} from "../translation/translate.service";
import { EventBrokerService } from '../_services/event.services';

@Component({
    selector: 'app',
    providers: [AuthenticationService, EventBrokerService],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent  {
    public supportedLanguages: any[];
    public translatedText: string;
    public isAuth: boolean = false;
    @Input()
    AuthEmitIn:boolean;


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

    selectLang(lang: string) {
        this._eventBroker.emit<string>("my-event", lang);
        console.log("EmitStart");
        this._translate.SetLanguage(lang);
    }


}

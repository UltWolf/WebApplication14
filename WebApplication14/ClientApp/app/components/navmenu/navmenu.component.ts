import {Component, Input, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { AuthenticationService } from '../_services/auth.services';
import { Router } from '@angular/router';
import {TranslateService} from "../translation/translate.service";


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    providers: [],
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit, OnChanges {

    ngOnChanges(changes: SimpleChanges): void {
        this.isAuth = this._authService.isLogg();
    }
    IsOn:boolean = false;
      public supportedLanguages: any[];
    public translatedText: string;
    
    ngOnInit():void {
        this.supportedLanguages = [
            { display: 'English', value: 'en' },
            { display: 'Русский', value: 'ru' },
        ];
        this.isAuth = this._authService.isLogg();
    }

    isCurrentLang(lang: string) {
        return lang === this._translate.GetLanguage();
    }

    selectLang(lang: string) {
        this._translate.SetLanguage(lang);
    }
    @Input() OnChanges:boolean;
    @Input()
    public isAuth: boolean = false;
   
    constructor(private _authService: AuthenticationService,private _translate: TranslateService, private router: Router) {
        
        this.isAuth = this._authService.isLogg();
    }

    logout() {
        this._authService.logout();
        this.router.navigate(['/login']);

    }
    Turn(){
        this.IsOn = !this.IsOn;
    }
}

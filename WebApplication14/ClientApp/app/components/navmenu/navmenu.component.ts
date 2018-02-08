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

    ngOnInit(): void {
        this.isAuth = this._authService.isLogg();

    }
    @Input() OnChanges:boolean;
    @Input()
    public isAuth: boolean = false;
    public supportedLanguages: any[];
    constructor(private _authService: AuthenticationService, private router: Router) {
        
        this.isAuth = this._authService.isLogg();
    }

    logout() {
        this._authService.logout();
        this.router.navigate(['/login']);

    }
}

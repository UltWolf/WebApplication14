import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/auth.services';
import { Router } from '@angular/router';
import {TranslateService} from "../translation/translate.service";


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    providers: [AuthenticationService],
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    ngOnInit(): void {
        this.isAuth = this._authService.isLogg();
    }
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

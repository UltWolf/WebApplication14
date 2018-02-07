﻿import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from './_services/auth.services';

@Injectable()
export class AdminGuard implements CanActivate {

    constructor(
        private auth: AuthenticationService,
        private router: Router
    ) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        if (!this.auth.isLogg()) {
            this.router.navigate(['/login']);
            return false;
        }
        if (!this.auth.isAdmin()) {
            this.router.navigate(['/permission']);
            return false;
            }

        return true;
    }

}
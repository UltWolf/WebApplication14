import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { Router } from '@angular/router';
import { User} from "../_models/user";
import { AuthenticationService } from '../_services/auth.services';

@Component({
    selector:"login",
    providers: [],
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';
    private auth: any
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) {
 
    }

    ngOnInit() {
    }

    login() {
        this.loading = true;
        const user = new User();
        user.LoginModel(this.model.Login, this.model.password);
        this.authenticationService.login(user)
            .subscribe(result => {
                if (result.ok === true) {
                    this.authenticationService.isLogg();
                    this.router.navigate(['/products']);
                } else {
                    this.error = 'Username or password is incorrect';
                    this.loading = false;
                }
            },err=>{
                this.error = 'Username or password is incorrect';
                this.loading = false;
            });
    }
}
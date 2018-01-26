import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../_services/auth.services';
import { User } from "../_models/user";

@Component({
    providers: [AuthenticationService],
    templateUrl: 'registration.component.html'
})

export class RegisterComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';
    private auth: any
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) {
        if (typeof window != 'undefined') {
            this.auth = localStorage.getItem("currentUser");
        }}

    ngOnInit() {
        this.authenticationService.logout();
    }

    register() {
        this.loading = true;
        const user = new User();
        user.RegistrationModel(this.model.First_name, this.model.Last_name, this.model.email, this.model.Password, this.model.ConfirmPassword, this.model.PlaceOfBirth, this.model.password);
        console.log(user);
        this.authenticationService.register(user)
           .subscribe(result => {
                if (result === true) {
                    this.router.navigate(['/']);
                } else {
                    this.error = 'Username or password is incorrect';
                    this.loading = false;
                }
            });
    }
}
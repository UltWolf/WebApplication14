import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../_services/auth.services';
import { User } from "../_models/user";

@Component({
    selector:"registration",
    providers: [AuthenticationService],
    templateUrl: 'registration.component.html'
})

export class RegisterComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';
    public IsActivated:boolean =  false;
    @Output()
    AuthChangeOutPut:EventEmitter<boolean>;
    private auth: any;
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) {
        if (typeof window != 'undefined') {
            this.auth = localStorage.getItem("currentUser");
        }
    }

    ngOnInit() {
    }

    register() {

        this.loading = true;
        const user = new User();
        user.RegistrationModel(this.model.First_name, this.model.Last_name, this.model.email, this.model.Password, this.model.ConfirmPassword, this.model.PlaceOfBirth);
        this.authenticationService.register(user)
            .subscribe((result) => {


                if (result.ok == true) {
                    this.router.navigate(['/login']);
                }
                this.error = result;
                this.loading = false;

            }, (err: Error) => {
                this.error = err.message;
                this.loading = false;
            });
    }
}
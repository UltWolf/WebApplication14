import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { BaseService } from "./base.service";
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { User } from "../_models/user";
import {JwtHelper} from "angular2-jwt";


@Injectable()
export class AuthenticationService extends BaseService {
    public token: string | null;
    
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    
    authNavStatus$ = this._authNavStatusSource.asObservable();
    private loggedIn = false;

    constructor(private http: Http) {
        super();
        if (typeof window !== 'undefined') {
            this.loggedIn = !!localStorage.getItem('auth_token');
            this._authNavStatusSource.next(this.loggedIn);
            
        }
        
          
    }
    register(User:User) 
    {  if (typeof window != 'undefined') {
        this.loggedIn = false;
        localStorage.removeItem('auth_token');
    }
        return this.http.post('http://localhost:55022/api/Account/', User).map((response) => {
            return response;
        });
       
    }

    login(User: User) 
    {  if (typeof window != 'undefined') {
        this.loggedIn = false;
        localStorage.removeItem('auth_token');
    }
        return this.http.post('http://localhost:55022/api/Auth/', User).map((response) => {
            localStorage.setItem('auth_token', response.json().auth_token);
            this.loggedIn = true;
            this._authNavStatusSource.next(true);
            return response;
        });
    }
    getToken():string {
        if (typeof window != 'undefined') {

            return localStorage.getItem('auth_token')||"";
        } else {
            return "notFound";
        }

    }
    jwtHelper: JwtHelper = new JwtHelper();

    getUserId() {

        var token = this.jwtHelper.decodeToken(this.getToken());
        return token.id;
    }

    logout(): void {  if (typeof window != 'undefined') {
        this.loggedIn = false;
        localStorage.removeItem('auth_token');
    }
    }

    isAdmin(): boolean {
        var decodedToken = this.jwtHelper.decodeToken(this.getToken());
        if (decodedToken.rol == "Admin") {
            return true;
        } else {
            return false;
        }
    }

    isLogg(): boolean {
        if (typeof window != 'undefined') {
            var token = localStorage.getItem('auth_token');
            if (token != null) {
                return true;
            } else {
                return false;
            }
        }
        return false;
    }

}
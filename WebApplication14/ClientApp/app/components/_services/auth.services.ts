import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { BaseService } from "./base.service";
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { User } from "../_models/user";

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
    register(user:User) 
    {    
       let body = JSON.stringify({ user});
       let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post('http://localhost:51075/api/Account/', body).map((response) => {
            console.log(response);
            return response.json();
        });
       
    }

    login(User: User) 
    {
     let headers = new Headers();
     headers.append('Content-Type', 'application/json');
     return this.http.post('http://localhost:51075/api/Auth', User).map((res) => res.json).map((response:any) => {
         console.log(response);
         if (typeof window !== 'undefined') {
             localStorage.setItem('auth_token', response.auth_token);
             this.loggedIn = true;
             this._authNavStatusSource.next(true);
             return true;
         }
                })
        }
    

    logout(): void {
        this.token = null;
        localStorage.removeItem('currentUser');
    }

    setToken(token: any, User: User):void{
        this.token = token;
        localStorage.setItem('currentUser', JSON.stringify({ username: User.Email, token: token }));
    }
}
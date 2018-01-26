import { Product } from './../_models/product';
import { Order } from './../_models/Order';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Inject } from '@angular/core';
import 'rxjs';   

import { Observable } from "rxjs/Observable";

@Injectable()
export class BuketService {
    constructor(private http: Http) {
    }

    baseUrl: string;

    deleteOrder(id:number) {
        return this.http.get('http://localhost:51075/api/Order/').map((response) => {
            return response.json();
        });
    }
    deleteOrders() {
        return this.http.get('http://localhost:51075/api/Orders/').map((response) => {
            return response.json();
        });
    }
    getOrders() {
        return this.http.get('http://localhost:51075/api/Orders').map((response) => {
            return response.json();
        });
    }
    addOrder(id: number, count: number) {
        return this.http.post('http://localhost:51075/api/Orders/' + id, count).map((response) => {
            console.log(response);
            return response.json();
        });
    }


 
}
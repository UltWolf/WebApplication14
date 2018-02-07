import { Product } from './../_models/product';
import { Order } from './../_models/Order';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Inject } from '@angular/core';
import 'rxjs';   

import { Observable } from "rxjs/Observable";
import { OrderModel } from '../_models/orderModel';
import { UserID } from '../_models/UserID';
import { confirmResult } from '../_models/confirmResult';

@Injectable()
export class BuketService {

    constructor(private http: Http) {
       
    }



    deleteOrder(id: number, IdUser: UserID) {
        return this.http.delete('api/Orders/' + id).map((response) => {
            return response;
        });
    }
    deleteOrders() {
        return this.http.get('api/Orders/').map((response) => {
            return response.json();
        });
    }
    getOrdersConfirm(id: number) {
        return this.http.get('paypal/create-payment/' + id).map((response: any) => {
            var result: confirmResult = response.json();
            return result;
        });
    }
    getOrders(id: number) {
        return this.http.get('api/Orders/' + id).map((response) => { 
            return response.json();
        });
    }
    addOrder(id: number, orderPost: OrderModel): Observable<boolean> {
        return this.http.post('api/Orders/' + id, orderPost).map(() => {
            return true;
        });
    }


 
}
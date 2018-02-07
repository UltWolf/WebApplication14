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

    baseUrl: string;

    deleteOrder(id: number, IdUser: UserID) {
        return this.http.delete('http://localhost:55022/api/Orders/' + id).map((response) => {
            return response;
        });
    }
    deleteOrders() {
        return this.http.get('http://localhost:55022/api/Orders/').map((response) => {
            return response.json();
        });
    }
    getOrdersConfirm(id: number) {
        return this.http.get('http://localhost:55022/paypal/create-payment/' + id).map((response: any) => {
            var result: confirmResult = response.json();
            return result;
        });
    }
    getOrders(id: number) {
        return this.http.get('http://localhost:55022/api/Orders/' + id).map((response) => { 
            return response.json();
        });
    }

    makePayment(sum: any) {
        return this.http.post('http://localhost:55022/paypal/make/payment?sum=' + sum, {})
            .map((response: Response) => response.json());
    }
    completePayment(paymentId: any, payerId: any) {
        return this.http.post('http://localhost:55022/paypal/complete/payment?paymentId=' + paymentId + '&payerId=' + payerId, {})
            .map((response: Response) => response.json());
    }
    addOrder(id: number, orderPost: OrderModel) {
        return this.http.post('http://localhost:55022/api/Orders/' + id, orderPost).map((response) => {
            return response.json();
        });
    }


 
}
import { Product } from './../_models/product';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Inject } from '@angular/core';
import 'rxjs';    

import { Observable } from "rxjs/Observable";

@Injectable()
export class ProductService {
    constructor(private http: Http) {
    }

    baseUrl: string;

    getProduct(id:number) {
        return this.http.get('http://localhost:51075/api/Product/'+id).map((response) => {
            return response.json();
        });
    }
    getProducts() {
        return this.http.get('http://localhost:51075/api/Product').map((response) => {
            return response.json();
        });
    }
    addProduct(Product: Product) {
        return this.http.post('http://localhost:51075/api/Product', Product).map((response) => {
            return response.json();

        });
    };


    editProduct(Product: any) {
        return this.http.put('http://localhost:51075/api/Product/Product.id}', Product).map((response) => {
            return response.json();
        });
    }
}
import { Product } from './../_models/product';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs';
import { sortModel } from '../_models/SortModel';

@Injectable()
export class ProductService {
    constructor(private http: Http) {
    }

    baseUrl: string;

    getProduct(id:number) {
        return this.http.get('http://localhost:55022/api/Product/'+id).map((response) => {
            return response.json();
        });
    }
    getProducts(sortModel: sortModel) {
        return this.http.post('http://localhost:55022/api/Products/', sortModel).map((response) => {
            return response.json();
        });
    }
    addProduct(Product: Product) {
        return this.http.post('http://localhost:55022/api/Product', Product).map((response) => {
            return response.json();

        });
    };


    editProduct(Product: any) {
        return this.http.put('http://localhost:55022/api/Product/Product.id', Product).map((response) => {
            return response.json();
        });
    }
}
import { Product } from './../_models/product';
import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs';
import { sortModel } from '../_models/SortModel';

@Injectable()
export class ProductService {
    
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }
    private _baseUrl: string;
 

    getProduct(id: number) {
        return this.http.get(this._baseUrl+ 'api/Product/'+ id).map((response) => {
            return response.json();
        });
    }
    getProducts(sortModel: sortModel) {
        return this.http.post(this._baseUrl +'api/Products/', sortModel).map((response) => {
            return response.json();
        });
    }
    addProduct(Product: Product) {
        return this.http.post(this._baseUrl +'api/Product', Product).map((response) => {
            return response.json();

        });
    };


    editProduct(Product: any) {
        return this.http.put('api/Product/Product.id', Product).map((response) => {
            return response.json();
        });
    }
}
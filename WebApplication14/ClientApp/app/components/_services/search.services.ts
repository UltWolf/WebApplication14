import { Product } from './../_models/product';
import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs';
import {SearchModel} from "../_models/searchModel";
import {Name} from "./name";


@Injectable()
export class SearchService {
    constructor(private http: Http) {
    }

    baseUrl: string;

    searchName(name: Name) {
        return this.http.post('api/search/LikeName/', name).map((response) => {
            return response.json();
        });
    }
    searchOptions(searchModel: SearchModel) {
        return this.http.post('api/search/', searchModel).map((response) => {
        return response.json();
    })
    }

}
import { Component, Input,Output,EventEmitter } from '@angular/core';
import { BuketService } from '../_services/buket.service';
import { Order } from '../_models/order'
import { OrderModel } from '../_models/orderModel';
import { AuthenticationService } from '../_services/auth.services';
import {SearchModel} from "../_models/searchModel";
import {SearchService} from "../_services/search.services";
import {Product} from "../_models/product";

@Component({
    providers:[SearchService],
    templateUrl:'fullsearch.component.html',

})
export class FullsearchComponent {
    name:string;
    products:Product[];
    category:string;
    country:string;
    minprice:number;
    price:number;
    Price:string;

    searchmodel:SearchModel;
    constructor(private _searchService:SearchService) {
    }
    search(){
        this.searchmodel.MinPrice = this.minprice;
        this.searchmodel.Category = this.category;
        this.searchmodel.Country = this.country;
        this.searchmodel.Name = this.name;
        this.searchmodel.Price = this.price;
        this._searchService.searchOptions(this.searchmodel).subscribe(
            (m)=>{
                this.products = m;
            }
        )
    }
}
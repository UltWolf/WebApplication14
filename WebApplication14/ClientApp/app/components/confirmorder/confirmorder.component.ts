import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';


import { DomSanitizer } from '@angular/platform-browser';
import {ProductService} from "../_services/product.services";
import {UploadService} from "../_services/uploading.services";
import {Order} from "../_models/order";
import {BuketService} from "../_services/buket.service";
import {AuthenticationService} from "../_services/auth.services";





@Component({
    providers: [BuketService, AuthenticationService],
    styleUrls:["confirmorder.component.css"],
    templateUrl: './confirmorder.component.html',
})
export class ConfirmorderComponent implements OnInit {
    orders: Order[];
    confirmLink: string;
    pathExcel: string;
    empty: boolean = true;
    loading:boolean = true;

    constructor(private _buketService: BuketService, private _authService: AuthenticationService) {
    }

    ngOnInit() {
        this.loading = true;
        this.GetOrders();
        this.GetListOrders();
    }
    GetOrders() {
        this._buketService.getOrders(this._authService.getUserId()).subscribe((Orders) => {
            this.orders = Orders;
        }
        )
    }
    GetListOrders() {
        this._buketService.getOrdersConfirm(this._authService.getUserId()).subscribe((href) => {
            if (href != null) {
                this.confirmLink = href.confirmPath;
                this.pathExcel = href.excelPath;
                this.empty = false;
            } else {
                this.empty = true;
            }
            this.loading = false;

        })
    }
        

    
}


import { Order } from './../_models/Order';
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { BuketService } from '../_services/buket.service';
import { AuthenticationService } from '../_services/auth.services';
import { Router } from '@angular/router';



@Component({
    selector: 'OrderUser',
    providers: [BuketService],
    styleUrls:['./productToOrder.component.css'],
    templateUrl: './productToOrder.component.html',
})
export class ProductToOrderComponent implements OnInit{

    Orders:Order[];
    IsOn: boolean = false;
    totalPrice: number = 0;
    constructor(private route:Router,private buketService: BuketService,private _authService:AuthenticationService) {
        this.GetListOrder();

      
        
    }

    ngOnInit(): void{
        this.GetListOrder();
        for (var o: number = 0; o < this.Orders.length; o++) {
            this.totalPrice += this.Orders[o].Count * this.Orders[o].product.price;
        }
    }

    GetListOrder() {
        if(this._authService.isLogg()) {
            this.buketService.getOrders(this._authService.getUserId()).subscribe((Order: Order[]) => {
                this.Orders = Order;
            })
        }
    }
    OnOrders(){
        this.IsOn = !this.IsOn;
    }
    BuyOrders() {
        this.route.navigate(['confirmorder']);
    }
    deleteOrders(){
        this.buketService.deleteOrders().subscribe(() => {
            this.buketService.getOrders(this._authService.getUserId());
     })
    }
}
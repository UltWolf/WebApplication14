import { Order } from './../_models/Order';
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { BuketService } from '../_services/buket.service';



@Component({
    selector: 'Order',
    providers: [BuketService],
    templateUrl: './productToOrder.component.html',
})
export class ProductToOrderComponent implements OnInit{

    Orders:Order[];

    constructor(private buketService: BuketService) {
   this.GetListOrder();
    }

    ngOnInit(): void{
       this.GetListOrder();
    }

    GetListOrder(){
        this.buketService.getOrders().subscribe((Order:Order[])=>{
            this.Orders = Order;
        })
    }

    deleteOrders(){
     this.buketService.deleteOrders().subscribe(()=>{
 
     })
    }

}
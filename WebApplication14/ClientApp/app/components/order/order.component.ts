import { Component, Input,Output,EventEmitter } from '@angular/core';
import { BuketService } from '../_services/buket.service';
import { Order } from '../_models/order'
import { OrderModel } from '../_models/orderModel';
import { AuthenticationService } from '../_services/auth.services';

@Component({
    selector:"order",
    providers:[BuketService],
    templateUrl:'order.component.html',
    
})
export class OrderComponent {
    count :number;
    @Input() order: Order;
    constructor(private buketService: BuketService, private _authService: AuthenticationService) {        
    }
    totalprice: number;
    NgOninit() {

        this.count = this.order.Count;
        this.totalprice = this.order.Count * this.order.product.price;
    }
   
    ChangeCount() {
        this.totalprice = this.count * this.order.product.price;
        if (this.count > 0) {

            const orderPost = new OrderModel(this._authService.getUserId(), this.count);
            this.buketService.addOrder(this.order.product.productId, orderPost).subscribe((order: Order) => {
            })
        }
    }
    Delete() {
        this.buketService.deleteOrder(this.order.orderId, this._authService.getUserId()).subscribe((result) => {
            this.buketService.getOrders(this._authService.getUserId());
        }
            );
    }


}
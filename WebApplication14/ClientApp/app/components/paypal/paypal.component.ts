import { Component, Input,Output,EventEmitter } from '@angular/core';
import { BuketService } from '../_services/buket.service';
import { Order } from '../_models/order'
import { OrderModel } from '../_models/orderModel';
import { AuthenticationService } from '../_services/auth.services';

@Component({
    providers:[],
    templateUrl:'paypal.component.html',

})
export class PaypalComponent {
    constructor() {
    }
}
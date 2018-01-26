import { Component, Input,Output,EventEmitter } from '@angular/core';
import { BuketService } from '../_services/buket.service';
import { Order } from '../_models/order'

@Component({
    selector:"order",
    providers:[BuketService],
    templateUrl:'order.component.html',
    
})
export class OrderComponent {
    count :number;
    @Output() deleteName: EventEmitter<void>;
    @Output() countProducts:EventEmitter<number>;
    @Input() order: Order;
    constructor(private buketService: BuketService ) {
    }

    NgOninit(){
    }
   
    ChangeCount(){
        this.order.Count = this.count;
        this.countProducts.emit(this.order.orderId);
    }
    Delete(){
        this.buketService.deleteOrder(this.order.orderId).subscribe(()=>{
            this.deleteName.emit();
        });
    }


}
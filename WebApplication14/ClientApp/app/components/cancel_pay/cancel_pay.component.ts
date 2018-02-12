import { Component, Input,Output,EventEmitter,OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    providers:[],
    templateUrl:'cancel_pay.component.html',
    styleUrls:["cancel_pay.component.css"]

})
export class CancelPayComponent implements OnInit{
    constructor(private router:Router) {
    }
    ngOnInit(){
    	  setTimeout((router: Router) => {
        this.router.navigate(['/products']);
    }, 5000); 
    }
  
}
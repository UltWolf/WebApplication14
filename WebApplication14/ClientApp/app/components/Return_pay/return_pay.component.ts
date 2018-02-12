import { Component, OnInit,EventEmitter } from '@angular/core';
import {Router} from '@angular/router'
@Component({
    providers:[],
    templateUrl:'return_pay.component.html',
    styleUrls:["return_pay.component.css"]

})
export class ReturnPayComponent implements OnInit {
    constructor(private router:Router) {
    }
    ngOnInit(){
    	  setTimeout((router: Router) => {
        this.router.navigate(['/products']);
    }, 5000); 
    }

}
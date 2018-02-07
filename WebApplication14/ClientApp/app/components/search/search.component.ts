import {Component} from '@angular/core';
import {SearchService} from "../_services/search.services";
import {Product} from "../_models/product";
import {Name} from "../_services/name";

@Component({
    selector:"search",
    providers: [SearchService],
    styleUrls:['search.component.css'],
    templateUrl: 'search.component.html'
})

export class SearchComponent {
    name:string;
    product:Product[];
    constructor(private _searchService:SearchService) {
    }

    search():void {
        if(this.name.length > 0){
            let name = new Name();
            name.name = this.name;
            this._searchService.searchName(name).subscribe((res)=>{
                
                this.product =  res;
            });
        }
    }
}
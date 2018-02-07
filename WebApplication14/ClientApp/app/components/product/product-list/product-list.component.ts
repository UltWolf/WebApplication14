
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../../_services/product.services';
import { UploadService } from '../../_services/uploading.services';
import { Product } from '../../_models/product';
import { DomSanitizer } from '@angular/platform-browser';
import {TranslateService} from "../../translation/translate.service";
import { ActivatedRoute } from '@angular/router';
import * as _ from 'underscore';
import { PagerService } from '../../_services/paginate.service';
import { sortModel } from '../../_models/SortModel';




@Component({
    selector: 'list-products',
    providers: [ProductService, UploadService, PagerService],
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{
    products: Product[];
    parametres = [
        { id: 1, name: "Name" },
        { id: 2, name: "Category" },
        { id: 3, name: "Country" },
        { id: 4, name: "Price" },
    ];
    sortedValue = [
        { id: 1, name: "+" },
        { id: 0, name: "-" }
    ]
    selectedValue = this.parametres[0];
    selectedValueSorted = this.sortedValue[0];
  constructor(private paginator:PagerService, private productService: ProductService,private route:ActivatedRoute, private fileService: UploadService, private sanitizer: DomSanitizer) {
  this.GetListProduct();
 
    }

  totalpages: number;
  pagenumber: number;
  pages: number[] =  [];
  hasPrevios: boolean;
  hasNext: boolean;
    key: any;
    ngOnInit(){

    }
    SetPage(numberpage: number): void{
        let model: sortModel = new sortModel();
        model.numberPager = numberpage;
        model.parametre = this.selectedValue.name || name;
        model.variantSort = this.selectedValueSorted.id;
            this.productService.getProducts(model).subscribe((res: any) => {
                this.totalpages = res.pgm.totalPages;
                this.pagenumber = res.pgm.pageNumber;
                this.hasPrevios = res.pgm.hasPreviousPage;
                this.hasNext = res.pgm.hasNextPage;
                this.products = res.products;
                for (var i = 0, j = 1; j <= this.totalpages; i++ , j++) {
                    this.pages[i] = j;
                }
                window.scrollTo(0, 0);
        })
}
    ChangeParametres() {
        let model: sortModel = new sortModel();
        model.numberPager = this.pagenumber;
        model.parametre = this.selectedValue.name || name;
        model.variantSort = this.selectedValueSorted.id;
        this.productService.getProducts(model).subscribe((res: any) => {
            this.totalpages = res.pgm.totalPages;
            this.pagenumber = res.pgm.pageNumber;
            this.hasPrevios = res.pgm.hasPreviousPage;
            this.hasNext = res.pgm.hasNextPage;
            this.products = res.products;
            for (var i = 0, j = 1; j <= this.totalpages; i++ , j++) {
                this.pages[i] = j;
            }
            window.scrollTo(0, 0);
        })
    }
    GetListProduct() {
        let model: sortModel = new sortModel();
        model.numberPager = 1;
        model.parametre = "Name";
        model.variantSort = this.selectedValueSorted.id;
        this.productService.getProducts(model).subscribe((res: any) => {  
            this.totalpages = res.pgm.totalPages;
            this.pagenumber = res.pgm.pageNumber;
            this.hasPrevios = res.pgm.hasPreviousPage;
            this.hasNext = res.pgm.hasNextPage;
            this.products = res.products;
            for (var i = 0,j=1; j <= this.totalpages; i++,j++){
                this.pages[i] = j;
            }      
        });
       
        
        }
      
    }


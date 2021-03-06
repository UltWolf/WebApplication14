import {TranslateService} from "../../translation";
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../../_services/product.services';
import { UploadService } from '../../_services/uploading.services';
import { Product } from '../../_models/product';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import * as _ from 'underscore';
import { PagerService } from '../../_services/paginate.service';
import { sortModel } from '../../_models/SortModel';
import { ChangeDetectorRef } from '@angular/core';



@Component({
    selector: 'list-products',
    styleUrls:['product-list.component.css'],
    providers: [ProductService, UploadService, PagerService],
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{
    products: Product[];
    previos_name: string = "Name";
    parametres: string[] =
    ["Name",
        "Category",
        "Country",
        "Price"
    ]
  constructor(private cdRef:ChangeDetectorRef, private _translate:TranslateService,private paginator:PagerService, private productService: ProductService,private route:ActivatedRoute, private fileService: UploadService, private sanitizer: DomSanitizer) {

    }

  totalpages: number;
  pagenumber: number = 1;
  variant_sort: boolean;
  pages: number[] =  [];
  hasPrevios: boolean;
  hasNext: boolean;
  loading:boolean = false;
    key: any;
    ngOnInit(){
        this.GetListProduct();
    }
        ngAfterViewChecked()
{
  this._translate.SetLanguage(this._translate.GetLanguage());
   this.cdRef.detectChanges();
}
    SetPage(numberpage: number): void{
        this.loading = true;
        this.products.length = 0;
        let model: sortModel = new sortModel();
        model.numberPager = numberpage;
        model.parametre = this.previos_name || "Name";
        model.variantSort = this.variant_sort;
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
                this.loading = false ;
        })
}
    setActiveStyle(page:any) {
        let styles:any = {};
        if(page==this.pagenumber){
            styles['color'] = "red";
        }

        return styles;
    }
    setActiveParameteStyle(p:any){
     let styles:any = {};
        if(p==this.previos_name){
            styles['color'] = "red";
            styles['font-weight'] = "bold";
        }

        return styles;   

    }

    ChangeParametre(name:string){
        this.loading = true;
        this.products = [];
        let model: sortModel = new sortModel();
        model.numberPager = this.pagenumber;
        model.parametre = name;
        if (name == this.previos_name) {
            model.variantSort = !model.variantSort;
        } else {
            model.variantSort = this.variant_sort;
            this.previos_name = name;
        }
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
            this.loading = false;
        })
    }
    GetListProduct() {
        this.loading = true;

        let model: sortModel = new sortModel();
        model.numberPager = 1;
        model.parametre = this.previos_name||"Name";
        model.variantSort = this.variant_sort;
        this.productService.getProducts(model).subscribe((res: any) => {  
            this.totalpages = res.pgm.totalPages;
            this.pagenumber = res.pgm.pageNumber;
            this.hasPrevios = res.pgm.hasPreviousPage;
            this.hasNext = res.pgm.hasNextPage;
            this.products = res.products;
            for (var i = 0,j=1; j <= this.totalpages; i++,j++){
                this.pages[i] = j;
            }
            this.loading =false;      
        });
       
        this.loading =false;
        }
      
    }


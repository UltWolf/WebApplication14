
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
    styleUrls:['product-list.component.css'],
    providers: [ProductService, UploadService, PagerService],
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{
    products: Product[];
    previos_name: string;
    parametres: string[] =
    ["Name",
        "Category",
        "Country",
        "Price"
    ]
  constructor(private paginator:PagerService, private productService: ProductService,private route:ActivatedRoute, private fileService: UploadService, private sanitizer: DomSanitizer) {

    }

  totalpages: number;
  pagenumber: number;
  variant_sort: boolean;
  pages: number[] =  [];
  hasPrevios: boolean;
  hasNext: boolean;
  loading:boolean = false;
    key: any;
    ngOnInit(){
        this.GetListProduct();
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


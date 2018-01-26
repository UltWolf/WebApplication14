import { Product } from './../_models/product';
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../_services/product.services';
import { UploadService } from '../_services/uploading.services';



@Component({
    selector: 'list-products',
    providers: [ProductService, UploadService],
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{
    products:Product[];

    constructor(private productService: ProductService, private fileService: UploadService) {
  this.GetListProduct();
    }

    ngOnInit(){
       this.GetListProduct();
    }

    GetListProduct(){
        this.productService.getProducts().subscribe((product:Product[])=>{
            this.products = product;
        })
    }

}
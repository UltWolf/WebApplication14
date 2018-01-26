import { Product } from './../_models/product';
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../_services/product.services';
import { UploadService } from '../_services/uploading.services';
import { ActivatedRoute } from "@angular/router";
import { BuketService } from "../_services/buket.service";



@Component({
    selector: 'product',
    providers: [ProductService, BuketService],
    templateUrl: './productsingle.component.html',
})
export class ProductSingleComponent implements OnInit {
    name: string;
    country: string;
    path: string;
    count: number;
    price: number;
    ProductId: number

    constructor(private productService: ProductService, private route: ActivatedRoute, private bucket: BuketService) {
        this.GetProduct();
    }

    ngOnInit() {

    }

    GetProduct() {
        this.productService.getProduct(this.route.snapshot.params['id']).subscribe((product: Product) => {
            this.name = product.name;
            this.country = product.country;
            this.price = product.price;
            this.ProductId = product.productId;
        })
    }
    AddProductToBucket() {
        console.log(this.ProductId + "  " + this.count);
        this.bucket.addOrder(this.ProductId, this.count).subscribe((product: Product) => {
           
        })
    }

}
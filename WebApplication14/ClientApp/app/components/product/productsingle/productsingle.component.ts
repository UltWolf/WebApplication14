
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { ProductService } from '../../_services/product.services';
import { BuketService } from '../../_services/buket.service';
import { Product } from '../../_models/product';
import { AuthenticationService } from '../../_services/auth.services';
import { OrderModel } from '../../_models/orderModel';
import {DomSanitizer} from "@angular/platform-browser";



@Component({
    selector: 'product',
    providers: [ProductService, BuketService],
    templateUrl: './productsingle.component.html',
})
export class ProductSingleComponent implements OnInit {
    name: string;
    country: string;
    path: any;
    count: number;
    price: number;
    ProductId: number

    constructor(private router:Router,private _authService: AuthenticationService,private productService: ProductService, private route: ActivatedRoute,private sanitizer:DomSanitizer, private bucket: BuketService) {
        
    }

    ngOnInit() {
        this.GetProduct();
    }

    GetProduct() {
        this.productService.getProduct(this.route.snapshot.params['id']).subscribe((product: Product) => {
            this.name = product.name;
            this.country = product.country;
            this.price = product.price;
            this.path =  this.path = this.sanitizer.bypassSecurityTrustResourceUrl(product.path);
            this.ProductId = product.productId;
        })
    }
    AddProductToBucket() {
        const orderPost = new OrderModel(this._authService.getUserId(), this.count);
        this.bucket.addOrder(this.ProductId, orderPost).subscribe((product) => {
            this.router.navigate(['products']);
        })
    }

}
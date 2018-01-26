import { Product } from './../_models/product';
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../_services/product.services';
import { UploadService } from '../_services/uploading.services';
import {DomSanitizer} from '@angular/platform-browser';


@Component({
    providers: [ProductService, UploadService],
    templateUrl: './product.component.html',
})
export class ProductComponent {
    category: string;
    name: string;
    country: string;
    price: number;
    imageSrc: any;
    imageWidth: number = 400;
    imageHeight: number = 200;

    constructor(private productService: ProductService, private fileService: UploadService) {
    }

    @ViewChild("fileInput") fileInput: any;
    UploadAvat($event: any) {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.fileService
                .upload(fileToUpload)
                .subscribe(res => {
                    this.imageSrc = res;
                });
        }
    }

    addProduct() {
        let product: Product = new Product();
        product.category = this.category;
        product.country = this.country;
        product.name = this.name;
        product.price = this.price;
        if (this.imageSrc != null) {
            product.path = this.imageSrc;
            this.productService.addProduct(product).subscribe((response: string) =>{
            });

        }
    }

}
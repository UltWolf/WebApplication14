
import { Response } from '@angular/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { ProductService } from '../../_services/product.services';
import { UploadService } from '../../_services/uploading.services';
import { AuthGuard } from '../../auth.guard';
import { Product } from '../../_models/product';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';


@Component({
    providers: [ProductService, UploadService,AuthGuard],
    templateUrl: './product.component.html',
})
export class ProductComponent {
    category: string;
    name: string;
    country: string;
    price: number;
    imagePost: string;
    imageSrc: any ;
    imageWidth: number = 400;
    imageHeight: number = 200;

    constructor(private route:Router,private productService: ProductService,  private fileService: UploadService, private sanitizer: DomSanitizer) {
    }

    @ViewChild("fileInput") fileInput: any;
    UploadAvat($event: any) {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.fileService
                .upload(fileToUpload)
                .subscribe(res => {
                    this.imagePost = "data:image/gif;base64," + res;
                    this.imageSrc = this.sanitizer.bypassSecurityTrustUrl("data:image/gif;base64,"+res);
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
            product.path = this.imagePost;
            this.productService.addProduct(product).subscribe((response) => {
                this.route.navigate(['/products']);
            });

        }
    }

}
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BuketService } from "./components/_services/buket.service";
import { ProductService } from "./components/_services/product.services";
import { UploadService } from "./components/_services/uploading.services";
import { AuthenticationService } from "./components/_services/auth.services";
import { HttpModule } from "@angular/http";
import { FormsModule } from "@angular/forms";


@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        AppModuleShared
    ],
    providers: [
        AuthenticationService,
        UploadService,
        ProductService,
        BuketService,
        AppComponent,
        { provide: 'BASE_URL', useFactory: getBaseUrl },
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}

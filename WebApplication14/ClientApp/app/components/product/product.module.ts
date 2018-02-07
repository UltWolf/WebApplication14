import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductSingleComponent } from './productsingle/productsingle.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductRoutingModule } from './product-routing.module';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from '../auth.guard';
import { ProductService } from '../_services/product.services';
import { AuthenticationService } from '../_services/auth.services';
import { SafeSrcPipe } from '../_pipes/safesrc.pipes';
import { AdminGuard } from '../admin.guard';
import {TranslationtModule} from "../translation/translation.module";
import {TRANSLATION_PROVIDERS} from "../translation/translation";
import {TranslateService} from "../translation";
import {ProductSingleInListComponent} from "./productsingleinlist/productsingleinlist.component";
import { EventBrokerService } from '../_services/event.services';

@NgModule({

    imports: [

        CommonModule,

            CommonModule,

            FormsModule,
        ProductRoutingModule,
        TranslationtModule



    ],
    exports: [],
    declarations: [ProductComponent, ProductSingleComponent,SafeSrcPipe],
    providers: [AuthGuard,AdminGuard,ProductService,AuthenticationService, TRANSLATION_PROVIDERS,
        TranslateService, EventBrokerService]

})

export class ProductModule { }
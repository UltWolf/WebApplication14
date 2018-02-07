import { NgModule, ModuleWithProviders } from '@angular/core';

import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { AuthGuard } from '../auth.guard';
import { ProductComponent } from './product/product.component';
import { ProductSingleComponent } from './productsingle/productsingle.component';
import { AdminGuard } from '../admin.guard';





const routes: ModuleWithProviders = RouterModule.forChild([

    { path: 'add', component: ProductComponent, canActivate: [AdminGuard] },
    { path: ':id', component: ProductSingleComponent,  }
   

]);



@NgModule({

    imports: [routes],

    exports: [RouterModule]

})

export class ProductRoutingModule { }
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProductComponent } from "./components/product/product.component";
import { ProductListComponent } from "./components/product-list/product-list.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/registration/registration.component";
import { OrderComponent } from "./components/order/order.component";
import { ProductToOrderComponent } from "./components/productToorders.component.ts/productToOrder.component";
import { ProductSingleComponent } from "./components/productsingle/productsingle.component";

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        OrderComponent,
        ProductListComponent,
        ProductToOrderComponent,
        ProductComponent,
        ProductSingleComponent,
        LoginComponent,
        RegisterComponent
       
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            
            { path: "home", component: HomeComponent },
            { path: 'product', component: ProductListComponent },
            { path: 'product/add', component: ProductComponent },
            { path: 'product/:id', component: ProductSingleComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ])
    ]
})
export class AppModuleShared {
}

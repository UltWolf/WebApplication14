import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {Http, HttpModule} from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/registration/registration.component";
import { OrderComponent } from "./components/order/order.component";
import { ProductToOrderComponent } from "./components/productToorders/productToOrder.component";
import { PermisionComponent } from './components/permision/permision.component';
import {TranslateService} from "./components/translation";
import {TRANSLATION_PROVIDERS} from "./components/translation/translation";
import {TranslationtModule} from "./components/translation/translation.module";
import { AuthGuard } from './components/auth.guard';
import { EventBrokerService } from './components/_services/event.services';
import {SearchComponent} from "./components/search/search.component";
import {PaypalComponent} from "./components/paypal/paypal.component";
import {FullsearchComponent} from "./components/fullsearch/fullsearch.component";
import {CancelPayComponent} from "./components/cancel_pay/cancel_pay.component";
import {ReturnPayComponent} from "./components/Return_pay/return_pay.component";
import {ConfirmorderComponent} from "./components/confirmorder/confirmorder.component";
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductSingleInListComponent } from './components/product/productsingleinlist/productsingleinlist.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        OrderComponent,
        ProductToOrderComponent,
        LoginComponent,
        RegisterComponent,
        PermisionComponent,
        SearchComponent,
        PaypalComponent,
        FullsearchComponent,
        ConfirmorderComponent,
        ReturnPayComponent,
        ProductListComponent,
        ProductSingleInListComponent,
        CancelPayComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        TranslationtModule,
        RouterModule.forRoot([
            { path: "orders",component: ProductToOrderComponent},
            { path: "home", component: HomeComponent },
            { path: 'login', component: LoginComponent},
            { path: 'register', component: RegisterComponent},
            { path: 'permission', component: PermisionComponent },
            { path: 'search', component:FullsearchComponent},
            { path: 'cancel', component:CancelPayComponent},
            { path: 'paypal/sold', component: ReturnPayComponent},
            { path: 'confirmorder', component: ConfirmorderComponent },
            { path: 'products', component: ProductListComponent },
            { path: 'product', loadChildren: './components/product/product.module#ProductModule' }
        ])
    ],
    providers:[
        TRANSLATION_PROVIDERS,
        TranslateService,
        AuthGuard,
        EventBrokerService
    ]
})
export class AppModuleShared {
}

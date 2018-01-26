import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
   
            ServerModule,
            AppModuleShared,
            HttpModule,
            FormsModule,
            BrowserModule
    ]
})
export class AppModule {
}

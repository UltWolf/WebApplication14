import {Product} from "../../_models/product";
import {Component, Input, OnInit, OnDestroy} from "@angular/core";
import {DomSanitizer} from "@angular/platform-browser";
import {TranslateService} from "../../translation";
import { EventBrokerService, IEventListener } from "../../_services/event.services";
import { ViewEncapsulation } from '@angular/core';


@Component({
    selector: "productsingleinlist",
    providers: [EventBrokerService],    
    styleUrls:['productsingleinlist.component.css'],
    templateUrl:"productsingleinlist.component.html",
    

})
export class ProductSingleInListComponent implements  OnInit,OnDestroy{
    @Input() product: Product;
    private _myEventListener: IEventListener;

    ngOnInit(): void {
        this.product.path = this.sanitizer.bypassSecurityTrustResourceUrl(this.product.path);
        this._translate.SetLanguage(this._translate.GetLanguage());
    }

    constructor(private sanitizer: DomSanitizer, private _translate: TranslateService, private _eventBroker: EventBrokerService) {
        this._myEventListener = _eventBroker.listen<string>("my-event", (value: string) => {
            console.log("emit end");
            this._translate.SetLanguage(value);
        });
    }
    public ngOnDestroy() {
        this._myEventListener.ignore();
    }
    isCurrentLang(lang: string) {
        return lang === this._translate.GetLanguage();
    }

    selectLang(lang: string) {
        this._translate.SetLanguage(lang);
    }
}
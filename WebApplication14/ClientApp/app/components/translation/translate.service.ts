import {Injectable, Inject} from '@angular/core';
import { TRANSLATIONS } from './translation'; // import our opaque token

@Injectable()
export class TranslateService {
    private _currentLang: string;

    public get currentLang() {
        return this._currentLang;
    }

    constructor(@Inject(TRANSLATIONS) private _translations: any) {
    }

    public use(lang: string): void {
        this._currentLang = lang;
    }
    public SetLanguage(lang:string){
        if (typeof window != 'undefined') {
            localStorage.setItem("current_language", lang);
        }
    }
    public GetLanguage(): string{
        if (typeof window != 'undefined') {
            return this._currentLang = localStorage.getItem("current_language") || "en";
        }
        return "en";
    }

    private translate(key: string): string {
        let translation = key;
        if (this._translations[this.currentLang] && this._translations[this.currentLang][key]) {
            return this._translations[this.currentLang][key];
        }
        return translation;
    }

    public instant(key: string) {
        return this.translate(key);
    }
}
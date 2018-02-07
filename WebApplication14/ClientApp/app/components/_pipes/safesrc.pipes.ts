import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({ name: 'safesrc' })
export class SafeSrcPipe implements PipeTransform{
    constructor(private sanitizer: DomSanitizer) { }

    transform(html: string) {
        var trusthtml = this.sanitizer.bypassSecurityTrustResourceUrl(html);
        return this.sanitizer.bypassSecurityTrustHtml(html).toString();
    }
}
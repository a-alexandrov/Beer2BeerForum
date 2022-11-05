import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Injectable({ providedIn: "root" })
export class Imageservice {
    constructor(private sanitizer: DomSanitizer) {}

    getImageFromByteArray(data: Blob, extension: string) {
        if (extension) { 
            let objectURL = `data:image/${extension};base64,${data}`;
            return this.sanitizer.bypassSecurityTrustUrl(objectURL);
        }
        else {
            return 'assets/img/birichko-static.png';
        }
    }
}
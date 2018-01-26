import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UploadService {
    constructor(private http: Http) {
    }
    public upload(fileToUpload: any) {
        let input = new FormData();
        input.append("file", fileToUpload);
        return this.http.post("/api/upload", input).map((response: Response) => {
            return response.json();
        });
    }
}
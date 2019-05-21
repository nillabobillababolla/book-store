import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BookService {

    constructor(private http: HttpClient) { }

    documentAdd(formData: FormData){
        const result = this.http.post(apiBaseUrl + '/DocumentAdd', formData, {reportProgress: true, observe: 'events'});

        return result;
    }

}
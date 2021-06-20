import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService
{
    private _apiRoot: string;
    private _defaultHeaders= new HttpHeaders();

    constructor(private _http$: HttpClient) 
    {
        this._apiRoot = `${document.getElementsByTagName('base')[0].href}api`;
        this._defaultHeaders = this._defaultHeaders.set('Content-Type', 'application/json');
        
    }

    public request<T>(method: string, url: string, options: any): Observable<T>
    {
        options = options || {};
        options.headers =  this._defaultHeaders;
        return this._http$.request<T>(method, `${this._apiRoot}/${url}`, options as Object);
    }
}

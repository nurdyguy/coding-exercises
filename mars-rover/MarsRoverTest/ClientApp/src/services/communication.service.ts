import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({ providedIn: 'root'})

export class CommunicationService
{
    private _showLoading = new Subject<boolean>();

    ShowLoading$ = this._showLoading.asObservable();

    constructor(){}

    ShowLoading(show:boolean)
    {
        this._showLoading.next(show);
    }
}
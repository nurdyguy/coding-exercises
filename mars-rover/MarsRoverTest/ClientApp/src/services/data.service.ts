import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { GetImagesRequest } from 'src/Models/RequestModels/GetImagesRequest';
import { GetImagesResponse } from 'src/Models/ResponseModels/GetImagesResponse';
import { RoverImage } from 'src/Models/RoverImage';
import { SearchFiltersResponse } from 'src/Models/ResponseModels/SearchFiltersResponse';


@Injectable({
    providedIn: 'root'
})
export class DataService
{
    constructor(private _api: ApiService, private _router: Router) { }

    TriggerDataCollection(): Observable<void>
    {
        return this._api.request('GET', 'Data/Process', {});
    }

    GetImage(id: number): Observable<RoverImage>
    {
        return this._api.request('GET', `RoverImage/${id}`, {});
    }

    GetImages(req: GetImagesRequest): Observable<GetImagesResponse>
    {
        return this._api.request('POST', 'RoverImage/Search', { body: req });
    }

    GetSearchOptions(): Observable<SearchFiltersResponse>
    {
        return this._api.request('GET', 'RoverImage/FilterOptions', {});
    }


    private handleError(err: any)
    {
        return err;
    }
}

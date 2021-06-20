import { Component, OnInit } from '@angular/core';
import { CommunicationService } from 'src/services/communication.service';
import { DataService } from 'src/services/data.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: [ './app.component.scss' ]
})
export class AppComponent implements OnInit
{
    title = 'Mars Rover Images';
    _showLoading: boolean = true;
    constructor(private _data: DataService, private _commService: CommunicationService)
    {        
        this._commService.ShowLoading$.subscribe(show => this.ShowHideLoading(show));
    }
    
    ngOnInit()
    {

    }

    ShowHideLoading(show: boolean)
    {
        Promise.resolve().then(() =>
        {
            this._showLoading = show;
        });
    }

}

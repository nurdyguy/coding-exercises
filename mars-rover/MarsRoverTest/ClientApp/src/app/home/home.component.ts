import { Component, OnInit } from '@angular/core';
import { CommunicationService } from 'src/services/communication.service';
import { DataService } from 'src/services/data.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: [ './home.component.scss' ]
})
export class HomeComponent implements OnInit
{
    _initializingData = true;
    constructor(private _dataService: DataService, private _commService: CommunicationService) { }

    ngOnInit(): void
    {
        this.InitializeData();
    }

    InitializeData()
    {
        this._commService.ShowLoading(true);
        let _this = this;
        this._dataService.TriggerDataCollection().subscribe(
            {
                next() 
                { 
                    _this._initializingData = false;
                    _this._commService.ShowLoading(false);
                }
            }
        );
    }

}

import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RoverImage } from 'src/Models/RoverImage';
import { DataService } from 'src/services/data.service';

@Component({
    selector: 'app-details',
    templateUrl: './details.component.html',
    styleUrls: [ './details.component.scss' ]
})
export class DetailsComponent implements OnInit
{
    @Input() imageId: number;
    _imageDetail : RoverImage;
    constructor(private _dataService: DataService, public _modal: NgbActiveModal) { }

    ngOnInit(): void
    {
        let _this = this;
        this._dataService.GetImage(this.imageId).subscribe({
            next(response)
            {
                _this._imageDetail = new RoverImage(response);
            }
        });
    }

}

import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetImagesRequest } from 'src/Models/RequestModels/GetImagesRequest';
import { RoverImage } from 'src/Models/RoverImage';
import { SearchFilter } from 'src/Models/SearchFilter';
import { CommunicationService } from 'src/services/communication.service';
import { DataService } from 'src/services/data.service';
import { DetailsComponent } from '../details/details.component';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: [ './search.component.scss' ]
})
export class SearchComponent implements OnInit
{
    _searchFilter: SearchFilter;
    _roverImages: RoverImage[] = [];
    _page: number;
    _perPage: number;
    _total: number;
    _totalPages: number;
    _pageNumbers: number[] = [];

    constructor(private _dataService: DataService, private _commService: CommunicationService, private _modalService: NgbModal)
    {
        this._searchFilter = new SearchFilter([ '7/13/2016', '2/27/2017', '6/2/2018' ], [ 'Curiosity', 'Opportunity' ]);
    }

    ngOnInit(): void
    {
        this.GetImages();
    }

    NewSearch()
    {
        this._page = 1;
        this.GetImages();
    }

    GetImages()
    {
        this._commService.ShowLoading(true);
        var req = new GetImagesRequest();
        req.Dates = this._searchFilter.Dates.filter(d => d.IsChecked).map(d => d.Value);
        req.RoverNames = this._searchFilter.Rovers.filter(r => r.IsChecked).map(r => r.Value);;
        req.Page = this._page;
        req.PerPage = this._perPage;
        var search = this._dataService.GetImages(req);
        let _this = this;
        search.subscribe({
            next(response)
            {
                _this._roverImages = [];
                response.RoverImages.forEach(ri => _this._roverImages.push(new RoverImage(ri)));
                _this._page = response.Page;
                _this._perPage = response.PerPage;
                _this._total = response.Total;
                _this._totalPages = Math.ceil(_this._total / _this._perPage);
                _this._pageNumbers = [];
                let pageTabs = 6;
                if(_this._page < pageTabs)
                    for(let i = 1; i <= pageTabs && i <= _this._totalPages; i++)
                        _this._pageNumbers.push(i);
                else
                    for(let i = _this._page - pageTabs + 2; i <= _this._page + 1 && i <= _this._totalPages; i++)
                        _this._pageNumbers.push(i);
                _this._commService.ShowLoading(false);
            }
        });
    }

    ToPage(pageNum: number)
    {
        if (pageNum != this._page)
        {
            this._page = pageNum;
            this.GetImages();
        }
    }

    ShowDetail(imageId: number)
    {
        let modalRef = this._modalService.open(DetailsComponent);
        modalRef.componentInstance.imageId = imageId;
    }

}

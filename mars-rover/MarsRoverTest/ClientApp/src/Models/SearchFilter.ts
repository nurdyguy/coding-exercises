import { SearchFilterItem } from "./SearchFilterItem";

export class SearchFilter{
    Dates: SearchFilterItem[];
    Rovers: SearchFilterItem[];

    constructor(dates: string[], rovers: string[])
    {
        this.Dates = dates.map(d => new SearchFilterItem(d, true));
        this.Rovers = rovers.map(r => new SearchFilterItem(r, true));
    }
}
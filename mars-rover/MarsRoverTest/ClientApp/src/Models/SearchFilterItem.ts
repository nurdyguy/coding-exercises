export class SearchFilterItem{
    Value: string;
    IsChecked: boolean;

    constructor(value: string, checked: boolean)
    {
        this.Value = value;
        this.IsChecked = checked;
    }
}
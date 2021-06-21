import { PagedRequest } from "./PagedRequest";

export class GetImagesRequest extends PagedRequest
{
    Dates: string[];
    RoverNames: string[];
}
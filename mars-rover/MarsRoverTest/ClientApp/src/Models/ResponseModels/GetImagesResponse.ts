import { RoverImage } from "../RoverImage";
import { PagedResponse } from "./PagedResponse";

export class GetImagesResponse extends PagedResponse
{
    RoverImages: RoverImage[];
}
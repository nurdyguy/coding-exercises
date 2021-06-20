import { RoverCamera } from "./RoverCamera";
import { Rover } from "./Rover";

export class RoverImage{
    Id: number;
    Camera: RoverCamera;
    EarthDate: string;
    Rover: Rover;
    ImageBytes: any;
    ImageType: string;
    
    public get Image(): string
    {
        return 'data:image/' + this.ImageType + ';base64,' + this.ImageBytes;
    }

    public get Date(): Date
    {
        return new Date(this.EarthDate);
    }

    constructor(roverImage: RoverImage)
    {
        this.Id = roverImage.Id;
        this.Camera = new RoverCamera(roverImage.Camera);
        this.EarthDate = roverImage.EarthDate;
        this.Rover = new Rover(roverImage.Rover);
        this.ImageBytes = roverImage.ImageBytes;
        this.ImageType = roverImage.ImageType;
    }
}
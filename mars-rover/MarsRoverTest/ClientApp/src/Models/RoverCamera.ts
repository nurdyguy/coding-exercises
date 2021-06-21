export class RoverCamera{
    Id: number;
    Name: string;
    Abbreviation: string;

    constructor(camera: RoverCamera)
    {
        this.Id = camera.Id;
        this.Name = camera.Name;
        this.Abbreviation = camera.Abbreviation;
    }
}
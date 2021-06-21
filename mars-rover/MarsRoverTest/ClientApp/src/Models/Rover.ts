export class Rover{
    Id: number;
    Name: string;

    constructor(rover: Rover)
    {
        this.Id = rover.Id;
        this.Name = rover.Name;
    }
}
using System;

namespace MarsRoverTest.Models
{
    public class RoverImage
    {
        public int Id { get; set; }
        public RoverCamera Camera { get; set; }
        public DateTime EarthDate { get; set; }
        public Rover Rover { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ImageType { get; set; }
    }
}

# Project Description
This project interacts with the NASA Mars Rover API (https://api.nasa.gov) in order to get Mars Rover images and their details.  
The project reads a text file containing dates and then queries the NASA API for all Rover photos taken on those dates.  The details and photos 
are then saved in MemCache and served to a frontend Angular application.

## Life Cycle
When a user hits the webpage a request is sent to the API which triggers the data initialization, that is the interaction between the API and the NASA API 
which retrieves and stores the data.  On subsequent hits the cache is validated to see if it is present and skips the data initialization if present in order to speed 
up subsequent page hits.  

Once the data is done being verified/initialized the user will see a search page where there are 5 checkboxes for search criterea.  The user can then change their 
search criterea from withing those bounds, the dates given as present in the text file and the two possible Rovers.  The page will show a list of 10 at a time, with a small image and some details. 
Since there are often more than 10 total images per search, pagination is included.

As the user searches through the pictures they can click on a row and see the full sized image along with some basic details about the image.
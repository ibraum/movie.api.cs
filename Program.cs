using Movie.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<MovieDto> movies = [
    new (1, "Le TOGO", "Raoul", new DateOnly(2000, 4, 17)),
    new (2, "Le GHANA", "Komi", new DateOnly(2003, 2, 7)),
    new (3, "Le BENIN", "Amorin", new DateOnly(1975, 9, 26)),
];

//OU
// List<MovieDto> movies = List<MovieDto>(){
//     new (1, "Le TOGO", "Raoul", new DateOnly(2000, 4, 17)),
//     new (2, "Le GHANA", "Komi", new DateOnly(2003, 2, 7)),
//     new (3, "Le BENIN", "Amorin", new DateOnly(1975, 9, 26)),
// };

app.MapGet("/", () => "Hello World!");
app.MapGet("/movies", () => movies);
app.MapGet("/movies/{id}", (int id) => movies.Find((movie) => {return movie.Id == id;}));

app.Run();

//DTO Data Transfer Object
//ESGIS@SARE ou esgis@SARE
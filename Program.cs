using Movie.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<MovieDto> movies = [
    new (1, "Le TOGO", "Raoul", new DateOnly(2000, 4, 17)),
    new (2, "Le GHANA", "Komi", new DateOnly(2003, 2, 7)),
    new (3, "Le BENIN", "Amorin", new DateOnly(1975, 9, 26)),
];

app.MapGet("/", () => "Hello World!");

app.MapGet("/movies", () => movies);

app.MapGet("/movies/{id}", (int id) => {
        var movieIndex = movies.FindIndex((movie) => {
            return movie.Id == id;
        });

        return (movieIndex == -1) ? Results.NotFound() : Results.Ok(movies[movieIndex]);
    }
).WithName("GetMovie");

app.MapPost("/movies",  (CreateMovieDto newMovie) => {
        MovieDto movie = new (
            Id: movies.Count + 1,
            Title: newMovie.Title,
            Director: newMovie.Director,
            ReleaseDate: newMovie.ReleaseDate
        );

        movies.Add(movie);
        
        return Results.CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
    }
);

app.MapPut("/movies/{id}", (UpdateMovieDto updateMovie, int id) => {
        var movieIndex = movies.FindIndex(movie => movie.Id == id);
        if (movieIndex == -1) {
            return Results.NotFound();
        }

        movies[movieIndex] = new MovieDto (
            Id: id,
            Title: updateMovie.Title,
            Director: updateMovie.Director,
            ReleaseDate: updateMovie.ReleaseDate
        );
        
        return Results.CreatedAtRoute("GetMovie", new { id = movies[movieIndex].Id }, updateMovie);
    }
);

app.MapDelete("/movies/{id}", (int id) => {
    movies.RemoveAll(movie => movie.Id == id);

    return Results.Ok();
});

app.Run();






















//DTO Data Transfer Object
//ESGIS@SARE ou esgis@SARE
//OU
// List<MovieDto> movies = List<MovieDto>(){
//     new (1, "Le TOGO", "Raoul", new DateOnly(2000, 4, 17)),
//     new (2, "Le GHANA", "Komi", new DateOnly(2003, 2, 7)),
//     new (3, "Le BENIN", "Amorin", new DateOnly(1975, 9, 26)),
// };
//OU
// app.MapGet("/movies/{id}", (int id) => movies.Find(movie => movie.Id == id));

// var oldMovie = movies.Find(movie => movie.Id == id);
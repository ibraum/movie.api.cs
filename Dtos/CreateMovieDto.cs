namespace Movie.Api.Dtos;

public record class CreateMovieDto 
(
    string Title,
    string Director,
    DateOnly ReleaseDate
);
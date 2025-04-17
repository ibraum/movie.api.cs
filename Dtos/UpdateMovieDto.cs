namespace Movie.Api.Dtos;

public record class UpdateMovieDto (
    string Title,
    string Director,
    DateOnly ReleaseDate
);
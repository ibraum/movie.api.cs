namespace Movie.Api.Dtos;

public record class MovieDto
(
    int Id,
    string Title,
    string Director,
    DateOnly ReleaseDate
);
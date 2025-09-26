using System;

namespace API.Dtos;

public record GameSummaryDto(
  Guid Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);

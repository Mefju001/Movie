using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public record MovieResponse
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required string Genre { get; init; }
        public required string Director { get; init; }
        public required List<Review> Reviews { get; init; }
    }
}

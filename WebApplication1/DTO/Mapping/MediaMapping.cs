using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.DTO.Mapping
{
    public class MediaMapping
    {
        public static MediaResponse ToResponse(Media media)
        {
            return new MediaResponse(
                media.Title,
                media.Description,
                GenreMapping.ToResponse(media.Genre),
                DirectorMapping.ToResponse(media.Director),
                media.ReleaseDate,
                media.Language,
                media.Reviews?.Select(r => ReviewMapping.ToResponse(r)).ToList() ?? new List<ReviewResponse>());
        }
    }
}

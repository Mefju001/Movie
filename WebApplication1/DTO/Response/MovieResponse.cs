using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public record MovieResponse(string Title, 
        string Description, string Genre, string DirectorName,
        string DirectorSurname, List<ReviewResponse>?Reviews);

}

using WebApplication1.Models;

namespace WebApplication1.DTO.Request
{
	public record MovieRequest(
		string Title, 
		string Description,
		GenreRequest Genre,
		DirectorRequest Director);

}

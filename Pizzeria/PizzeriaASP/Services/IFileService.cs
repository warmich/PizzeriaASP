using Microsoft.AspNetCore.Http;

namespace Pizzeria.ASP.Services
{
	public interface IFileService
	{
		string AddFile(IFormFile file);
		void Delete(string image);
	}
}
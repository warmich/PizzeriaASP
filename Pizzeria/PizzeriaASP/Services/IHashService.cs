namespace Pizzeria.ASP.Services
{
	public interface IHashService
	{
		string Hash(string password, string salt = null);
	}
}
using ModelsLibrary;

namespace MobileCart.Services;

public interface ICocktailService
{
    List<Cocktails> MyCocktails {get;set;}

    Task GetCocktails();
    Task<Cocktails?> GetCocktailsByID(int id);
    Task CreateCocktail(Cocktails cocktails);

    Task UpdateCocktails(int id, Cocktails cocktails);
    Task DeleteCocktail(int id);

}
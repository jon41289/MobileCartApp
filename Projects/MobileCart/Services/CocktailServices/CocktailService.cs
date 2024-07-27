using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Routing;
using ModelsLibrary;

namespace MobileCart.Services;

public class CocktailService : ICocktailService
{
    private readonly HttpClient _http;
    private readonly NavigationManager navigationManager;

    public CocktailService(HttpClient http, NavigationManager navigationManager)
    {
        _http = http;
        this.navigationManager = navigationManager;
        _http.BaseAddress=new Uri("http://localhost:5094");
    }
    public List<Cocktails> MyCocktails { get; set; } = new List<Cocktails>();

    public async Task CreateCocktail(Cocktails cocktails)
    {
        await _http.PostAsJsonAsync(_http.BaseAddress+"api/Cocktail", cocktails);
        navigationManager.NavigateTo("cocktails");
    }

    public async Task DeleteCocktail(int id)
    {
        var result = await _http.DeleteAsync($"{_http.BaseAddress}api/Cocktail/{id}");
        navigationManager.NavigateTo("cocktails");
    }

    public async Task GetCocktails()
    {
        var results = await _http.GetFromJsonAsync<List<Cocktails>>(_http.BaseAddress+"api/Cocktail");
        if(results is not null)
            MyCocktails = results;
    }

    public async Task<Cocktails?> GetCocktailsByID(int id)
    {
        var test = _http.BaseAddress+"api/Cocktail/"+id;
        var result = await _http.GetFromJsonAsync<Cocktails>(test);
        
        if(result is not null)
            return result;

        return null;
     
    }

    public async Task UpdateCocktails(int id, Cocktails cocktails)
    {
        // await _http.PutAsJsonAsync(_http.BaseAddress+"api/Cocktail/"+id,cocktails);
        await _http.PutAsJsonAsync($"{_http.BaseAddress}api/Cocktail/{id}",cocktails);

        navigationManager.NavigateTo("cocktails");
    }
}
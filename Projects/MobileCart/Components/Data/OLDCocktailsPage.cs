using Microsoft.AspNetCore.Components;
using ModelsLibrary;
namespace MobileCart.Data;

public partial class CocktailsPage:ComponentBase
{

    public List<Cocktails> myCocktail = new List<Cocktails>();


    [Inject]
    private HttpClient Http{ get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.myCocktail = await Http.GetFromJsonAsync<List<Cocktails>>("http://localhost:5094/api/Cocktail");
    }
}
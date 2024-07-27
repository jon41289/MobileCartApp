using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCartAPI.Data;
using MobileCartAPI.Migrations;
// using MobileCartAPI.Models; 
using ModelsLibrary;

namespace MobileCartAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CocktailController : Controller
{
     private readonly AppDbContext _appDbContext;
    public CocktailController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddCocktails(Cocktails cocktails)
    {
        _appDbContext.Cocktails.Add(cocktails);
        await _appDbContext.SaveChangesAsync();

        return Ok(cocktails);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cocktails = await _appDbContext.Cocktails.ToListAsync();
        return Ok(cocktails);
    
    }

    [HttpGet("{id}")]
    public async Task<Cocktails?> GetCocktailByID([FromRoute]int id)
    {
        var cocktail = await _appDbContext.Cocktails.FindAsync(id);
        return cocktail;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCocktail([FromRoute] int id, [FromBody] Cocktails cocktail)
    {
        var myCocktail = _appDbContext.Cocktails.FirstOrDefault(x => x.Id == id);

        if(myCocktail == null)
            return NotFound();

        myCocktail.Name = cocktail.Name;
        myCocktail.Rating  = cocktail.Rating;
        myCocktail.MainSpirt = cocktail.MainSpirt;
        myCocktail.Flavor = cocktail.Flavor;
        myCocktail.SkillLevel = cocktail.SkillLevel;
        myCocktail.Discription = cocktail.Discription;
        myCocktail.Ingredients  = cocktail.Ingredients;
        await _appDbContext.SaveChangesAsync();
        
        return Ok(myCocktail);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCocktail(int id)
    {
        var myCocktail = await _appDbContext.Cocktails.FindAsync(id);

        if(myCocktail == null)
            return NotFound();

        _appDbContext.Cocktails.Remove(myCocktail);

        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}
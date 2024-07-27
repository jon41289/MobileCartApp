// using System.CompentModel.DataAnnotationsValidator;
namespace ModelsLibrary;

public class Cocktails{
    public int Id { get; set;}

    // [MinLength(3,ErrorMessage = "Name is to short")]
    public string Name { get; set;}
    public int Rating { get; set;}
    public string  MainSpirt { get; set;}

    // [MinLength(3,ErrorMessage = "Flavor is to short")]
    public string Flavor { get; set;}
    public string SkillLevel { get; set;}
    public string Discription { get; set;}
    public string Ingredients { get; set;}
    public string Instructions  { get; set;}

}
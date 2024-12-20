namespace RettioAPI.Models;

using RettioAPI.Interfaces;

public class User : IUser
{
    public int Id {get; set;}
    public string FirstName {get; set; }
    public string LastName {get; set; }
    public string DateOfBirth {get; set; }
    public string Username {get; set; }
    public string Password {get; set; }
}
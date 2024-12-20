namespace RettioAPI.Models;

using RettioAPI.Interfaces;

public class User : IUser
{
    public required int Id {get; set;}
    public required string FirstName {get; set; }
    public required string LastName {get; set; }
    public required string DateOfBirth {get; set; }
    public required string Username {get; set; }
    public required string Password {get; set; }
    public required string PhoneNumber {get; set; }

}
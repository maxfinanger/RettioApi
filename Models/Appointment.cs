namespace RettioAPI.Models;

public class Appointment
{
    public required int Id { get; set; }
    public required string Category { get; set; }
    public required string Date { get; set; }
    public required string Time { get; set; }
    public required int Price { get; set; }
    public required int UserId { get; set; }
}

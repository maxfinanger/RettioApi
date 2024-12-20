namespace RettioAPI.Models;

public class Appointment
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int Price { get; set; }
    public int UserId { get; set; }
}

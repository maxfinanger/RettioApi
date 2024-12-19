namespace RettioAPI.Models;

public class Appointment
{
    public int Id { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public int Price { get; set; }
    public int UserId { get; set; }
}

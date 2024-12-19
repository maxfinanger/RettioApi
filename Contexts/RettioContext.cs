namespace RettioAPI.Contexts;

using RettioAPI.Models;
using Microsoft.EntityFrameworkCore;


public class RettioContext : DbContext
{
    public RettioContext(DbContextOptions<RettioContext> options):base(options){} 

    public DbSet<Appointment> Appointment {get; set;}  
    public DbSet<User> User {get; set;}  


}
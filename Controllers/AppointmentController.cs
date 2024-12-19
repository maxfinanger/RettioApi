
using Microsoft.AspNetCore.Mvc;
using RettioAPI.Contexts;
using RettioAPI.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly RettioContext context;

    public AppointmentController(RettioContext _context)
    {
        context = _context;
    }

    // Get all appointments
    [HttpGet]
    public async Task<ActionResult<List<Appointment>>> Get()
    {
        try 
        {
            var appointments = await context.Appointment.ToListAsync();
            return appointments.Any() ? Ok(appointments) : NotFound();
        }
        catch 
        {
            return StatusCode(500);
        }
    }

    // Get a single appointment by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> Get(int id)
    {
        try 
        {
            var appointment = await context.Appointment.FindAsync(id);
            return appointment != null ? Ok(appointment) : NotFound();
        }
        catch 
        {
            return StatusCode(500);
        }
    }


    // Create a new appointment
    [HttpPost]
    public async Task<ActionResult<User>> Post(User newAppointment)
    {
        try
        {
            context.User.Add(newAppointment);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = newAppointment.Id }, newAppointment);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Update an existing appointment
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Appointment updatedAppointment)
    {
        if (id != updatedAppointment.Id)
        {
            return BadRequest();
        }

        context.Entry(updatedAppointment).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AppointmentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Delete an existing appointment
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await context.Appointment.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        context.Appointment.Remove(appointment);
        await context.SaveChangesAsync();

        return NoContent();
    }

    // Check if a driver exists
    private bool AppointmentExists(int id)
    {
        return context.Appointment.Any(e => e.Id == id);
    }
}

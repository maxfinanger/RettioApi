using Microsoft.AspNetCore.Mvc;
using RettioAPI.Contexts;
using RettioAPI.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly RettioContext context;

    public UserController(RettioContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        try 
        {
            var users = await context.User.ToListAsync();
            return users.Any() ? Ok(users) : NotFound();
        }
        catch 
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        try 
        {
            var user = await context.User.FindAsync(id);
            return user != null ? Ok(user) : NotFound();
        }
        catch 
        {
            return StatusCode(500);
        }
    }

    [HttpGet("by-username/{username}")]
    public async Task<ActionResult<User>> GetByUsername(string username)
    {
        try 
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Username == username);
            return user != null ? Ok(user) : NotFound();
        }
        catch 
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User newUser)
    {
        try
        {
            context.User.Add(newUser);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User updatedUser)
    {
        if (id != updatedUser.Id)
        {
            return BadRequest();
        }

        context.Entry(updatedUser).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        context.User.Remove(user);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(int id)
    {
        return context.User.Any(e => e.Id == id);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Password != loginRequest.Password)
            {
                return Unauthorized("Invalid password");
            }

            return Ok(new
            {
                Message = "Login successful",
                UserId = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            });
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}


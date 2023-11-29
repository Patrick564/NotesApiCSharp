using Microsoft.EntityFrameworkCore;
using NotesApiCSharp.Data;
using NotesApiCSharp.Models;

namespace NotesApiCSharp.Controllers;

public abstract class UserController
{
    public static async Task<IResult> GetAll(NotesSharpDb db)
    {
        return TypedResults.Ok(await db.Users.ToListAsync());
    }

    public static async Task<IResult> GetById(int id, NotesSharpDb db)
    {
        var user = await db.Users.FindAsync(id);
        
        return user != null ? TypedResults.Ok(user) : TypedResults.NotFound();
    }

    public static async Task<IResult> Register(User user, NotesSharpDb db)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return TypedResults.Created($"/v1/users/{user.Id}", user);
    }
}

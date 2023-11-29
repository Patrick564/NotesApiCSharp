using Microsoft.EntityFrameworkCore;
using NotesApiCSharp.Models;

namespace NotesApiCSharp.Data;

public class NotesSharpDb : DbContext
{
    public NotesSharpDb(DbContextOptions<NotesSharpDb> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
}

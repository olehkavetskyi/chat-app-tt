using Domain.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ChatDbContext : DbContext
{ 

    public DbSet<Message> Messages { get; set; }

    
    public ChatDbContext(DbContextOptions<ChatDbContext> options)
    : base(options)
    {
    }

    protected ChatDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Message>().HasKey(m => m.Id);
    }

}

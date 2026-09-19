using Microsoft.EntityFrameworkCore;

public class WebApplicationWeek3Context(DbContextOptions<WebApplicationWeek3Context> options) : DbContext(options)
{
    public DbSet<WebApplicationWeek3.Models.AccountHolder> AccountHolder { get; set; } = default!;
}

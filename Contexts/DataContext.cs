using Crito.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crito.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<SubscriberEntity> Subscribers { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
}

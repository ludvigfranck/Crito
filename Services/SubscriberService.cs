using Crito.Contexts;
using Crito.Models;
using Crito.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crito.Services;

public class SubscriberService
{
    private readonly DataContext _context;

    public SubscriberService(DataContext context)
    {
        _context = context;
    }

    public async Task<NewsLetterForm> AddSubscriberAsync(NewsLetterForm form)
    {
        if (!await FindSubscriberAsync(form))
        {
            await _context.Subscribers.AddAsync(new SubscriberEntity { Email = form.Email });
            await _context.SaveChangesAsync();
            return form;
        }

        return null!;
    }

    private async Task<bool> FindSubscriberAsync(NewsLetterForm form)
    {
        return await _context.Subscribers.AnyAsync(x => x.Email == form.Email);
    }
}

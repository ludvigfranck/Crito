using Crito.Contexts;
using Crito.Models.Entities;
using Crito.Models;
using Microsoft.EntityFrameworkCore;

namespace Crito.Services;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task<ContactForm> AddContactAsync(ContactForm form)
    {
        if (!await FindContactAsync(form))
        {
            await _context.Contacts.AddAsync(new ContactEntity
            {
                Email = form.Email,
                Name = form.Name,
                Message = form.Message
            });
            await _context.SaveChangesAsync();
            return form;
        }

        return null!;
    }

    private async Task<bool> FindContactAsync(ContactForm form)
    {
        return await _context.Contacts.AnyAsync(x => x.Email == form.Email);
    }
}

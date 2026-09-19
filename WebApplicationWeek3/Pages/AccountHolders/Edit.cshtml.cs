using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWeek3.Models;

namespace WebApplicationWeek3.Pages.AccountHolderPages;

public class EditModel : PageModel
{
    private readonly WebApplicationWeek3Context _context;

    public EditModel(WebApplicationWeek3Context context)
    {
        _context = context;
    }

    [BindProperty]
    public AccountHolder AccountHolder { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? accountholderid)
    {
        if (accountholderid is null)
        {
            return NotFound();
        }

        var accountholder = await _context.AccountHolder.FirstOrDefaultAsync(m => m.AccountHolderId == accountholderid);
        if (accountholder is null)
        {
            return NotFound();
        }
        AccountHolder = accountholder;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(AccountHolder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountHolderExists(AccountHolder.AccountHolderId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AccountHolderExists(int accountholderid)
    {
        return _context.AccountHolder.Any(e => e.AccountHolderId == accountholderid);
    }
}

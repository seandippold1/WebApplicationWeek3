using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWeek3.Models;

namespace WebApplicationWeek3.Pages.AccountHolderPages;

public class DeleteModel : PageModel
{
    private readonly WebApplicationWeek3Context _context;

    public DeleteModel(WebApplicationWeek3Context context)
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
        else
        {
            AccountHolder = accountholder;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? accountholderid)
    {
        if (accountholderid is null)
        {
            return NotFound();
        }

        var accountholder = await _context.AccountHolder.FindAsync(accountholderid);
        if (accountholder != null)
        {
            AccountHolder = accountholder;
            _context.AccountHolder.Remove(AccountHolder);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWeek3.Models;

namespace WebApplicationWeek3.Pages.BankAccountPages;

public class CreateModel : PageModel
{
    private readonly WebApplicationWeek3Context _context;

    public CreateModel(WebApplicationWeek3Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public BankAccount BankAccount { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.BankAccount.Add(BankAccount);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

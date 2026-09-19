using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationWeek3.Models;

namespace WebApplicationWeek3.Pages.BankAccountPages;

public class IndexModel : PageModel
{
    private readonly WebApplicationWeek3Context _context;

    public IndexModel(WebApplicationWeek3Context context)
    {
        _context = context;
    }

    public IList<BankAccount> BankAccount { get; set; } = default!;

    public async Task OnGetAsync()
    {
        BankAccount = await _context.BankAccount.ToListAsync();
    }
}

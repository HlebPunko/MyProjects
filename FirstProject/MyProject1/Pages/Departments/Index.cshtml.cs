using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyProject1.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly MyProject1.Data.SchoolContext _context;

        public IndexModel(MyProject1.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Models.Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
            }
        }
    }
}

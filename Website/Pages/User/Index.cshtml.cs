using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Models;

namespace Website.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly Website.Data.WebsiteDatabaseContext _context;

        public IndexModel(Website.Data.WebsiteDatabaseContext context)
        {
            _context = context;
        }

        public IList<Website.Models.User> User { get;set; }


        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository;

namespace MusicEShop.Web.Views.ShoppingCart
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cart = await _context.Carts
                .Include(c => c.User).ToListAsync();
        }
    }
}

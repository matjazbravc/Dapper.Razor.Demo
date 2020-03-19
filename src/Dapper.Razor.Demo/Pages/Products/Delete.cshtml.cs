using System;
using System.Threading.Tasks;
using Dapper.Razor.Demo.Models;
using Dapper.Razor.Demo.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dapper.Razor.Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product = await _productRepository.GetAsync(id.Value);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(id.Value);
            return RedirectToPage("/Index");
        }
    }
}
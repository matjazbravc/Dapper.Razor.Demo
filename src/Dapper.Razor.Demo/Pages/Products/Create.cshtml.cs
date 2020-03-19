using Dapper.Razor.Demo.Models;
using Dapper.Razor.Demo.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Dapper.Razor.Demo.Pages.Products
{
    public class CreateModel : PageModel
    {
        IProductRepository _productRepository;

        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var count = await _productRepository.InsertAsync(Product);
                if (count > 0)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
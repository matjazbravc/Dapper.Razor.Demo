using Dapper.Razor.Demo.Models;
using Dapper.Razor.Demo.Services.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Dapper.Razor.Demo.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public EditModel(IProductRepository appSettingsCustomRepository)
        {
            _productRepository = appSettingsCustomRepository ?? throw new ArgumentNullException(nameof(appSettingsCustomRepository));
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _productRepository.UpdateAsync(Product);
            }
            catch
            {
                if (!await ProductExistsAsync(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/Index");
        }

        private async Task<bool> ProductExistsAsync(int id)
        {
            var product = await _productRepository.GetAsync(id).ConfigureAwait(false);
            return product != null;
        }
    }
}
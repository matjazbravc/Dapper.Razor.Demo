using Dapper.Razor.Demo.Models;
using Dapper.Razor.Demo.Services.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Dapper.Razor.Demo.Pages
{
    /// <summary>
    /// Index Page Model
    /// </summary>
    public class IndexModel : PageModel
    {
        readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _productRepository.CreateTableIfNotExistsAsync();
        }

        [BindProperty]
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Initializes any state needed for the page, in our case Products List
        /// </summary>
        public async Task OnGetAsync()
        {
            Products = await _productRepository.GetAsync().ConfigureAwait(false);
        }
    }
}
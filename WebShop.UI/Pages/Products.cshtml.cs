using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Access;
using WebShop.DTO;

namespace WebShop.UI.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IDataAccess<ProductDTO> _dataAccess;

        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        [BindProperty]
        public ProductDTO Product { get; set; }
        public int ProductID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ProductsModel(IDataAccess<ProductDTO> dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void OnGet()
        {
            Products = _dataAccess.LoadAll().ToList();
        }
        public ActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = _dataAccess.LoadAll().Where(p => p.ProductName.ToLower().Contains(SearchTerm.ToLower())).ToList();
                return Page();
            }
            return RedirectToPage("/Products");
        }
        public IActionResult OnPostAddToCart()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage();
            }
            return Page();
        }
        //public IActionResult OnPostSearch()
        //{

        //}
    }
}

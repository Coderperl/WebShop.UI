using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WebShop.Access;
using WebShop.DTO;

namespace WebShop.UI.Pages
{
    public class ProductsModel : PageModel
    {
        public readonly IDataAccess<ProductDTO> prodAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;

        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        [BindProperty]
        public ProductDTO Product { get; set; }
        [BindProperty]
        public int ProductID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ShoppingCartDTO Cart { get; set; }

        public CustomerDTO Customer { get; set; }
        public ProductsModel(IDataAccess<ProductDTO> prodAccess, IDataAccess<CustomerDTO> custAccess)
        {
            this.prodAccess = prodAccess;
            this.custAccess = custAccess;
        }
        public void OnGet()
        {
            Products = prodAccess.LoadAll().ToList();
            Customer = custAccess.LoadById((int)HttpContext.Session.GetInt32("CustomerId"));
        }
        public ActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = prodAccess.LoadAll().Where(p => p.ProductName.ToLower().Contains(SearchTerm.ToLower())).ToList();
                return Page();
            }
            return RedirectToPage("/Products");
        }
    }
}

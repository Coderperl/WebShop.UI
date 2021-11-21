using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using WebShop.Access;
using WebShop.DTO;

namespace WebShop.UI.Pages
{
    public class CartModel : PageModel
    {
        public readonly IDataAccess<ProductDTO> prodAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        private readonly IDataAccess<ShoppingCartDTO> cartAccess;

        
        
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Cart { get; set; }



        public CartModel(IDataAccess<ProductDTO> prodAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<ShoppingCartDTO> cartAccess)
        {
            this.prodAccess = prodAccess;
            this.custAccess = custAccess;
            this.cartAccess = cartAccess;
        }
        public ActionResult OnGet()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            if (Id.HasValue)
            {
                ShoppingCartDTO userCart = cartAccess.LoadById(Id.Value);
                if (userCart == null)
                {
                    userCart = new(Id.Value);
                    cartAccess.Save(userCart);
                    Cart = userCart.Products;
                    return Page();
                }
                else
                {
                    Cart = userCart.Products;
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Customers");
            }
        }
        public IActionResult OnPostRemove(int index)
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.LoadById(Id.Value);
            userCart.Products.RemoveAt(index);
            cartAccess.Update(userCart);
            return RedirectToPage("/Cart");

        }

        public IActionResult OnPostAddToCart(int ProductId)
        {

            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.LoadById(Id.Value);
            if (userCart == null)
            {
                userCart = new(Id.Value);
                ProductDTO product = prodAccess.LoadById(ProductId);
                userCart.Products.Add(product);
                cartAccess.Save(userCart);
            }
            else
            {
                ProductDTO product = prodAccess.LoadById(ProductId);
                userCart.Products.Add(product);
                cartAccess.Update(userCart);
            }
            return RedirectToPage("/Products");
        }
    }
}

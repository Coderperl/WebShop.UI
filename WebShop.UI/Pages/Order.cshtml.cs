using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Access;
using WebShop.DTO;

namespace WebShop.UI.Pages
{
    public class OrderModel : PageModel
    {
        public readonly IDataAccess<OrderDTO> orderAccess;
        public readonly IDataAccess<ShoppingCartDTO> cartAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        public readonly IDataAccess<CardDTO> cardAccess;
        public readonly IDataAccess<ProductDTO> prodAccess;

        public List<OrderDTO> Orders { get; set; }
        public CustomerDTO Customer { get; set; }


        public OrderModel(IDataAccess<OrderDTO> orderAccess, IDataAccess<ShoppingCartDTO> cartAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<CardDTO> cardAccess, IDataAccess<ProductDTO> prodAccess)
        {
            this.orderAccess = orderAccess;
            this.cartAccess = cartAccess;
            this.custAccess = custAccess;
            this.cardAccess = cardAccess;
            this.prodAccess = prodAccess;
        }
        public IActionResult OnGetPlaceOrder()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.LoadById(Id.Value);
            if (userCart == null)
            {
                return RedirectToPage("/Customers");
            }
            else
            {
                CustomerDTO Customer = custAccess.LoadById(Id.Value);
                OrderDTO newOrder = new OrderDTO(0, Customer, userCart.Products);
                orderAccess.Save(newOrder);
                cartAccess.Update(new ShoppingCartDTO(Id.Value));
                return RedirectToPage("/Order");
            }
        }
        public IActionResult OnGet()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            if (Id.HasValue)
            {
              Orders = orderAccess.LoadAll().Where(o => o.Customer.CustomerID == Id.Value).ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("/Customers");
            }
            
            
        }
    }
}

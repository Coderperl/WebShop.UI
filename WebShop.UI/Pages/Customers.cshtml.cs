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
    public class CustomerModel : PageModel
    {
        public readonly IDataAccess<CustomerDTO> _custAccess;
        public readonly IDataAccess<CardDTO> _cardAccess;
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public List<CustomerDTO> Customers { get; set; }
        [BindProperty]
        public CustomerDTO Customer { get; set; }
        [BindProperty]
        public List<CardDTO> Card { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }
        
        public CustomerModel(IDataAccess<CustomerDTO> dataAccess, IDataAccess<CardDTO> cardAccess)
        {
            _custAccess = dataAccess;
            _cardAccess = cardAccess;
        }
        public void OnGet()
        {
           Customers = _custAccess.LoadAll().ToList();
           Card = _cardAccess.LoadAll().ToList();
           Customer = _custAccess.LoadById(CustomerId);
        }
        public IActionResult OnPostCustomer()
        {
            Customer = _custAccess.LoadById(Customer.CustomerID);
            HttpContext.Session.SetInt32("CustomerId", Customer.CustomerID);
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Products");
            }
            return Page();
        }
        
    }
}

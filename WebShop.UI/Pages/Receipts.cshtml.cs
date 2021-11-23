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
    public class ReceiptsModel : PageModel
    {
        private readonly IDataAccess<RecieptDTO> receiptAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        public readonly IDataAccess<CardDTO> cardAccess;

        public List<RecieptDTO> Receipts { get; set; }
        public ReceiptsModel(IDataAccess<RecieptDTO> receiptAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<CardDTO> cardAccess)
        {
            this.receiptAccess = receiptAccess;
            this.custAccess = custAccess;
            this.cardAccess = cardAccess;
        }
        public void OnGet()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            Receipts = receiptAccess.LoadAll().ToList().Where(x => x.Order.Customer.CustomerID == Id).ToList();
        }
    }
}

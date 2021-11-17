using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public CustomerDTO Customer { get; set; }
        public ProductDTO Product { get; set; }
        public RecieptDTO Reciept { get; set; }
        public bool IsPaid { get; set; }
    }
}

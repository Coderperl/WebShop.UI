using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class OrderDTO
    {
        

        public int OrderId { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Products { get; set; }
        public bool IsPaid { get; set; }
        public OrderDTO(int OrderId, CustomerDTO Customer, List<ProductDTO> Products)
        {
            this.OrderId = OrderId;
            this.Customer = Customer;
            this.Products = Products;
        }
    }
}

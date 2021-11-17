using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class ShoppingCartDTO
    {
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Products { get; set; }

    }
}

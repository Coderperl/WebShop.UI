using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Products { get; set; }
        public ShoppingCartDTO(int Id, List<ProductDTO> products)
        {
            this.Id = Id;
            Products = products;
        }

    }
}

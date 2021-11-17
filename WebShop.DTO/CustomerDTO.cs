using System;

namespace WebShop.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public CardDTO CardId { get; set; }

    }
}

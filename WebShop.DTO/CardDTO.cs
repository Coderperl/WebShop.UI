using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class CardDTO
    {
        public int CardId { get; set; }
        public int CardNumber { get; set; }
    }
    public enum CardType
    {
        DebitCard,
        CreditCard
    };
}

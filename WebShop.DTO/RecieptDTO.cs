﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DTO
{
    public class RecieptDTO
    {
        public int ReceiptId { get; set; }
        public OrderDTO Order { get; set; }

        

    }
}

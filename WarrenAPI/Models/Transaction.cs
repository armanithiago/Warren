using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarrenAPI.Models
{
    public class Transaction
    {
        public int AccountNumber { get; set; }
        public decimal Value { get; set; }
    }
}

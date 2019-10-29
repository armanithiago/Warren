using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarrenAPI.Enums;

namespace WarrenAPI.Models
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal TransactionValue { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WarrenAPI.Enums
{
    public enum TransactionType
    {
        [Description("Depósito")]
        Deposit,
        [Description("Saque")]
        Withdraw,
        [Description("Pagamento")]
        Payment
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.DAO
{
    public class ReceiptModel
    {
        public string id = "N/A", date = "N/A", table = "N/A", cashier = "N/A", discount = "N/A", total = "N/A", totalAfterDiscount = "N/A";
        public List<ReceiptItem> items;
    }
    public class ReceiptItem
    {
        public string id = "N/A", name = "N/A", unit = "N/A", quantity = "N/A", subtotal = "N/A";
    }
}

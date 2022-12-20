using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace text.DTO
{
    internal class Bill
    {
        public Bill(int iD, int iDNhanvien, int status, int discount, decimal total, DateTime? creation)
        {
            ID = iD;
            IDNhanvien = iDNhanvien;
            Status = status;
            Discount = discount;
            Total = total;
            Creation = creation;
        }
        public Bill(int iDNhanvien, int status, int discount, decimal total)
            : this(0, iDNhanvien, status, discount, total, null)
        {
            // DO NOT DELETE
        }
        public Bill(DataRow dataRow, List<BillDetail> items)
        {
            ID = (int)dataRow["id"];
            IDNhanvien = (int)dataRow["idNhanVien"];
            Status = (int)dataRow["status"];
            Discount = (int)dataRow["discount"];
            Total = (decimal)dataRow["total"];
            Creation = DateTime.ParseExact((string)dataRow["creation"], dateFormat, CultureInfo.InvariantCulture);
            Items = items;
        }
        public Bill(DataRow dataRow) : this(dataRow, DAO.BillDAO.GetBillDetails((int)dataRow["id"]))
        {
            // DO NOT DELETE
        }
        public int ID { get; set; }
        public int IDNhanvien { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime? Creation { get; set; }
        public List<BillDetail> Items { get; set; }
        public static readonly string dateFormat = "yyyy/MM/dd";
    }

    internal class BillDetail
    {
        public BillDetail(int billID, int foodID, int quantity)
        {
            BillID = billID;
            FoodID = foodID;
            Quantity = quantity;
        }
        public BillDetail(int foodID, int quantity) : this(0, foodID, quantity)
        {
            // DO NOT DELETE
        }
        public BillDetail(DataRow dataRow)
        {
            BillID = (int)dataRow["billId"];
            FoodID = (int)dataRow["foodId"];
            Quantity = (int)dataRow["quantity"];
        }
        public int BillID { get; set; }
        public int FoodID { get; set; }
        public int Quantity { get; set; }
    }
}
